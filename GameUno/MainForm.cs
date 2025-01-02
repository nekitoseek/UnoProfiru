using Microsoft.VisualBasic.Logging;

namespace GameUno
{
    public partial class MainForm : Form
    {
        private int ThisOrder; // хранит номер игрока, чей ход текущий
        private readonly Dictionary<string, Image> Images; // словарь для карт
        private Card? TopCard = null; // верхняя карта в стопке
        private bool BotsMode = false; // бот

        public MainForm()
        {
            InitializeComponent();
            Images = Helper.GetResourceImages();
            Game.DirectionChanged += Game_DirectionChanged;
            Game.RunChanged += Game_RunChanged;
            Game.StepOrderChanged += Game_StepOrderChanged;
            PlayPlaces.PlayerChanged += Players_PlayerChanged;
            DropDesk.TopCardChanged += DropDesk_TopCardChanged;
        }

        // загрузка
        private void MainForm_Load(object sender, EventArgs e)
        {
            PurchaseDesk.ReshuffleCards();
            Game.Update();
            PlayPlaces.Update();
            tsslStatusMessage.Text = ThisOrder == 1
                ? "Ожидайте начала игры..."
                : "Начните игру при комплекте игроков...";
        }

        // закрытие
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ThisOrder == 1)
            {
                Game.StopGame();
                Game.Clear();
                PlayPlaces.Clear();
                DropDesk.Clear();
                Log.Clear();
            }
            else if (ThisOrder > 1)
            {
                PlayPlaces.ClearPlace(ThisOrder);
            }
        }

        // интерфейс игроков
        private void Players_PlayerChanged(object sender, PlayerEventArgs args)
        {
            while (lvPlayers.Items.Count < args.StepOrder)
            {
                var lvi = new ListViewItem();
                lvi.SubItems.Add("0");
                lvi.SubItems.Add("0");
                lvPlayers.Items.Add(lvi);
            }
            var index = args.StepOrder - 1;
            var name = args.Name;
            lvPlayers.Items[index].Text = BotsMode && string.IsNullOrWhiteSpace(name) ? $"Бот {args.StepOrder}" : name;
            lvPlayers.Items[index].SubItems[1].Text = args.CountCards == 1 ? "uno" : args.CountCards.ToString();
            lvPlayers.Items[index].SubItems[2].Text = args.PlayScore.ToString();
        }

        // когда кладем новую карту на верх колоды
        private void DropDesk_TopCardChanged(object? sender, EventArgs? e)
        {
            var topCard = (Card?)sender;
            if (TopCard != null && TopCard.ID == topCard?.ID) return;
            TopCard = topCard;
            panelDirection.Invalidate();
            UpdateHandsCards();
            if (TopCard == null) return;
            UpdateAroundArrows(TopCard);
        }

        // смена очерёдности хода
        private void Game_StepOrderChanged(object? sender, EventArgs? e)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender), "Sender не может быть null.");
            var stepOrder = (int)sender;
            UpdatePlayerPositionAndStatus(stepOrder);
        }

        private void UpdatePlayerPositionAndStatus(int stepOrder)
        {
            if (stepOrder >= 1 && stepOrder <= Game.PlaceCount && stepOrder - 1 < lvPlayers.Items.Count)
            {
                var lvi = lvPlayers.Items[stepOrder - 1];
                lvi.Selected = true;
                lvPlayers.FocusedItem = lvi;
                var otherPlayerName = PlayPlaces.GetPlayerName(stepOrder);
                var isBot = BotsMode && otherPlayerName.StartsWith("Бот");
                var thisPlayerName = PlayPlaces.GetPlayerName(ThisOrder);

                var total = PlayPlaces.GetPlayScore(stepOrder);
                if (total > Game.TargetScore)
                    tsslStatusMessage.Text = $"{PlayPlaces.GetPlayerName(stepOrder)} выиграл эту игру со счётом: {total}";
                else
                    tsslStatusMessage.Text =
                    stepOrder > 0
                    ? stepOrder == ThisOrder ? $"Ваш ход, {thisPlayerName}" : $"{otherPlayerName} ходит..."
                    : "Ожидание начала игры...";
                timerStepAsBot.Enabled = Game.Run && isBot;
            }
        }

        // управление действиями бота
        private void timerStepAsBot_Tick(object sender, EventArgs e)
        {
            timerStepAsBot.Enabled = false;
            var waitTime = 0;
            var rand = new Random();
            waitTime = rand.Next(500, 1000);
            var botOrder = Game.StepOrder;
            var cards = Helper.GetHandsCards(botOrder);
            // если нужная карта есть - бросает
            if (CanDropAnyCardsFromHands(botOrder))
            {
                CalculateBotCard(botOrder, cards);
                if (waitTime > 0) Thread.Sleep(waitTime);
                Game.NextStep();
            }
            else
            {
                botOrder = Game.StepOrder;
                // бот берёт карту из колоды
                GetACardFromPurchase(botOrder, isBot: true);
                if (CanDropAnyCardsFromHands(botOrder))
                {
                    cards = Helper.GetHandsCards(botOrder);
                    CalculateBotCard(botOrder, cards);
                    Game.NextStep();
                }
                if (waitTime > 0) Thread.Sleep(waitTime);
            }
        }

        // стратегия игры бота
        private void CalculateBotCard(int botOrder, List<Card> cards)
        {
            var card = cards.FirstOrDefault(crd => CompareCardsRules.Compare(TopCard.Color, TopCard, crd)); // здесь стратегия бота при выборе карты
            Log.Add($"{PlayPlaces.GetPlayerName(botOrder)} кладёт карту {card?.Name}");
            UpdateCardActions(card, botOrder, isBot: true);
            PlayPlaces.AddOrSubCountCards(botOrder, -1);
            DropDesk.DropACard(card);
            DropDesk.Update();
            if (Helper.GetHandsCards(botOrder).Count() == 1)
                Log.Add($"{PlayPlaces.GetPlayerName(botOrder)} говорит UNO!");
            if (Helper.GetHandsCards(botOrder).Count() == 0)
                CalculateWinScore(botOrder);
        }

        // подсчет очков
        private void CalculateWinScore(int order)
        {
            var score = Helper.CalculateWinScore(order);
            var total = PlayPlaces.AddPlayScore(order, score);
            PlayPlaces.Update();
            Log.Add($"{PlayPlaces.GetPlayerName(order)} выиграл этот раунд со счётом: {score}");
            if (total >= Game.TargetScore)
            {
                timerStepAsBot.Enabled = false;
                Game.StopGame();
                ThisOrder = 0;
                Log.Add($"{PlayPlaces.GetPlayerName(order)} выиграл игру со счётом: {total}");
                tsslStatusMessage.Text = $"{PlayPlaces.GetPlayerName(order)} выиграл эту игру со счётом: {total}";
                return;
            }
            Log.Add();
            DropDesk.Clear();
            DropDesk.DropACard(TopCard);
            DropDesk.Update();
            PurchaseDesk.ReshuffleCards();
            PurchaseDesk.DropThisCardId(TopCard.ID);
            Game.GetPurchaseCardToHands();
            UpdateHandsCards();
            Game.Round++;
            Log.Add($"=== Раунд: {Game.Round} ===");
            Log.Add($"Первая карта карта {TopCard.Name}");
        }

        // запуск/остановка игры
        private void Game_RunChanged(object? sender, EventArgs? e)
        {
            var run = sender as bool?;
            if (run == null)
            {
                throw new InvalidOperationException("Sender должен быть типа bool.");
            }
            if (!run.Value)
            {
                panelDirection.BackgroundImage = null;
                return;
            }
            StartPlayerGame();
        }

        // старт игры
        private void StartPlayerGame()
        {
            if (!BotsMode)
                UpdateHandsCards();
            if (ThisOrder == 1)
            {
                if (TopCard == null)
                {
                    Helper.GetPurchaseCardToDropFirstCard();
                    Log.Clear();
                }
                DropDesk.Update();
                if (TopCard != null)
                {
                    Log.Add($"=== Раунд: {Game.Round} ===");
                    Log.Add($"Первая карта карта {TopCard.Name}");
                    if (TopCard.Feature?.AllowedOperations.HasFlag(AllowedOperations.Wild) == true)
                    {
                        var rand = new Random();
                        TopCard.ChangeWildColor((CardColor)rand.Next(4));
                        UpdateAroundArrows(TopCard);
                    }
                }
            }
        }

        // есть ли на руках подходящая карта для сброса
        private bool CanDropAnyCardsFromHands(int stepOrder)
        {
            if (TopCard != null)
            {
                var card = TopCard;
                var cards = Helper.GetHandsCards(stepOrder);
                return cards.Any(crd => CompareCardsRules.Compare(card.Color, card, crd));
            }
            return false;
        }

        // может ли конкретная карта быть сброшенной на верх колоды
        private bool CanDropTheCardsFromHands(Card? droping)
        {
            if (TopCard != null && droping != null)
            {
                var card = TopCard;
                return CompareCardsRules.Compare(card.Color, card, droping);
            }
            return false;
        }

        // обновление отображения карт на руках у игрока
        private void UpdateHandsCards()
        {
            lvCards.Items.Clear();
            imageListCards.Images.Clear();
            var cards = Helper.GetHandsCards(ThisOrder);
            if (cards.Count() < 8)
                imageListCards.ImageSize = new Size(80, 120); // разрешение
            else
                imageListCards.ImageSize = new Size(40, 60); // разрешение
            foreach (var card in cards)
            {
                imageListCards.Images.Add(card.Name, Images[card.Name]);
                var lvi = new ListViewItem(card.Name) { Tag = card };
                lvi.ImageKey = card.Name;
                lvCards.Items.Add(lvi);
            }
        }

        // когда меняется направление хода
        private void Game_DirectionChanged(object? sender, EventArgs? e)
        {
            if (TopCard == null) return;
            UpdateAroundArrows(TopCard);
        }

        // стрелки в соответствии с направлением хода и цветом карты
        private void UpdateAroundArrows(Card card)
        {
            switch (card.Color)
            {
                case CardColor.Red:
                    panelDirection.BackgroundImage = !Game.Direction
                        ? Properties.Resources.Красные_стрелки_по_часовой
                        : Properties.Resources.Красные_стрелки_против_часовой;
                    break;
                case CardColor.Yellow:
                    panelDirection.BackgroundImage = !Game.Direction
                        ? Properties.Resources.Желтые_стрелки_по_часовой
                        : Properties.Resources.Желтые_стрелки_против_часовой;
                    break;
                case CardColor.Green:
                    panelDirection.BackgroundImage = !Game.Direction
                        ? Properties.Resources.Зеленые_стрелки_по_часовой
                        : Properties.Resources.Зеленые_стрелки_против_часовой;
                    break;
                case CardColor.Blue:
                    panelDirection.BackgroundImage = !Game.Direction
                        ? Properties.Resources.Синие_стрелки_по_часовой
                        : Properties.Resources.Синие_стрелки_против_часовой;
                    break;
            }
        }

        // периодическое обновление состояния игры и интерфейса
        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            Game.Update();
            PlayPlaces.Update();
            DropDesk.Update();
            lbPurchaseCardsCount.Text = PurchaseDesk.CardsCount().ToString();
            lvCards.Enabled = Game.Run && ThisOrder == Game.StepOrder;
            UpdatePlayerPositionAndStatus(Game.StepOrder);
            getCardToolStripMenuItem.Enabled = btnGetACardFromPurchase.Visible =
                Game.Run && Game.StepOrder == ThisOrder && !CanDropAnyCardsFromHands(ThisOrder);
            UpdateMessages();
        }

        // обновление интерфейса лога
        private void UpdateMessages()
        {
            tbLog.Lines = Log.SelectLastMessages(100);
            tbLog.SelectionStart = tbLog.TextLength;
            tbLog.ScrollToCaret();
        }

        // очистка игры по клику кнопки
        private void clearGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.StopGame();
            ClearGame();
            ThisOrder = 0;
        }

        // сама очистка игры
        private static void ClearGame()
        {
            Log.Clear();
            Game.Clear();
            Game.Update();
            PlayPlaces.Clear();
            PlayPlaces.Update();
        }

        // подключение к игре по кнопке
        private void connectToGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectToGame();
        }

        // само подключение
        private void ConnectToGame()
        {
            PlayPlaces.DefinePlaceOrder("Игрок");
            PlayPlaces.Update();
            ThisOrder = PlayPlaces.Order;
            var name = $"Игрок {ThisOrder}";
            PlayPlaces.SetPlayerName(ThisOrder, name);
            if (ThisOrder > 0)
                Text = $"Игра \"UNO\" - {name}";
        }

        // менюшка
        private void gameToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            Game.Update();
            PlayPlaces.Update();

            connectToGameToolStripMenuItem.Enabled = ThisOrder == 0;
            gameWithBotsToolStripMenuItem.Enabled = runTheGameToolStripMenuItem.Enabled = ThisOrder == 1 && !Game.Run;
            stopTheGameToolStripMenuItem.Enabled = ThisOrder == 1 && Game.Run;
        }

        // начать игру (кнопка)
        private void runTheGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ThisOrder == 1)
            {
                BotsMode = false;
                PurchaseDesk.ReshuffleCards();
                Game.RunGame();
                Game.StepOrder = 1;
                TopCard = null;
                StartPlayerGame();
            }
        }

        // остановить игру (кнопка)
        private void stopTheGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ThisOrder == 1)
            {
                Game.StopGame();
                ClearGame();
            }
        }

        // выйти (кнопка)
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGetACardFromPurchase_Click(object sender, EventArgs e)
        {
            GetACardFromPurchase(ThisOrder);
        }

        // забор карты из колоды
        private void GetACardFromPurchase(int stepOrder, bool isBot = false)
        {
            var lastCard = Helper.GetPurchaseCardToHands(stepOrder, 1);
            PlayPlaces.AddOrSubCountCards(stepOrder, 1);
            if (!isBot)
                UpdateHandsCards();
            Log.Add($"{PlayPlaces.GetPlayerName(stepOrder)} берёт карту из колоды");
            Game.Update();
            if (CanDropTheCardsFromHands(lastCard))
            {
                if (!isBot)
                {
                    var lvi = lvCards.Items.Cast<ListViewItem>().FirstOrDefault(item => item.Tag == lastCard);
                    if (lvi != null)
                    {
                        lvi.Selected = true;
                        lvCards.FocusedItem = lvi;
                        lvi.EnsureVisible();
                    }
                }
            }
            else
            {
                Log.Add($"{PlayPlaces.GetPlayerName(stepOrder)} пропускает ход");
                Game.NextStep();
            }
        }

        // бросить карту(дабл клик)
        private void lvCards_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvCards.SelectedItems.Count == 0) return;
            var card = (Card?)lvCards.SelectedItems[0].Tag;
            if (CanDropTheCardsFromHands(card))
            {
                Log.Add($"{PlayPlaces.GetPlayerName(ThisOrder)} кладёт карту {card?.Name}");
                UpdateCardActions(card, ThisOrder);
                PlayPlaces.AddOrSubCountCards(ThisOrder, -1);
                DropDesk.DropACard(card);
                DropDesk.Update();
                UpdateHandsCards();
                btnSayUnoIfOneCard.Visible = Helper.GetHandsCards(ThisOrder).Count() == 1;
                if (Helper.GetHandsCards(ThisOrder).Count() == 0)
                    CalculateWinScore(ThisOrder);
                else
                    Game.NextStep();
            }
            else
            {
                tsslStatusMessage.BackColor = Color.Red;
                timerErrorStatus.Tag = tsslStatusMessage.Text;
                tsslStatusMessage.Text = $"Карту \"{card?.Name}\" нельзя положить";
                timerErrorStatus.Enabled = true; // сообщение об ошибке, что карту нельзя бросить
            }
        }

        // сброс сообщения об ошибке
        private void timerErrorStatus_Tick(object sender, EventArgs e)
        {
            timerErrorStatus.Enabled = false;
            tsslStatusMessage.BackColor = Color.Transparent;
            tsslStatusMessage.Text = (string?)timerErrorStatus.Tag;
        }

        // карты с действиями
        private void UpdateCardActions(Card? card, int stepOrder, bool isBot = false)
        {
            var nextStepOrder = Game.GetNextStepOrder(stepOrder);
            if (card?.Feature?.AllowedOperations.HasFlag(AllowedOperations.Rotate) == true)
            {
                // карта смены направления
                Log.Add($"{PlayPlaces.GetPlayerName(nextStepOrder)} меняет направление игры и пропускает ход");
                Game.ReverseDirection();
                Game.PrevStep();
            }
            else
            if (card?.Feature?.AllowedOperations.HasFlag(AllowedOperations.Skip) == true)
            {
                // карта пропуска хода
                Log.Add($"{PlayPlaces.GetPlayerName(nextStepOrder)} пропускает ход");
                Game.NextStep();
            }
            else
            if (card?.Feature?.AllowedOperations.HasFlag(AllowedOperations.TakeTwo) == true)
            {
                // карта +2
                Log.Add($"{PlayPlaces.GetPlayerName(nextStepOrder)} берёт две карты и пропускает ход");
                Helper.GetPurchaseCardToHands(nextStepOrder, 2);
                PlayPlaces.AddOrSubCountCards(nextStepOrder, 2);
                Game.NextStep();
            }
            else
            if (card?.Feature?.AllowedOperations.HasFlag(AllowedOperations.Wild) == true)
            {
                // карта выбора цвета
                if (card.Feature.AllowedOperations.HasFlag(AllowedOperations.Color) &&
                    !card.Feature.AllowedOperations.HasFlag(AllowedOperations.TakeFour))
                {
                    CardColor selected;
                    if (!isBot)
                    {
                        // форма для выбора карт
                        var frm = new SelectColorForm();
                        frm.ShowDialog();
                        selected = frm.Color;
                    }
                    else // если бот цвет выбирается рандомно
                    {
                        var rand = new Random();
                        selected = (CardColor)rand.Next(4); // здесь стратегия бота при выборе цвета
                    }
                    card.ChangeWildColor(selected); // цвет карты и цвет стрелок направления
                    UpdateAroundArrows(card);
                    Log.Add($"{PlayPlaces.GetPlayerName(stepOrder)} выбрал цвет: {selected}");
                }
                // дикая карта (+4)
                else if (card.Feature.AllowedOperations.HasFlag(AllowedOperations.Color | AllowedOperations.TakeFour))
                {
                    CardColor selected;
                    if (!isBot)
                    {
                        var frm = new SelectColorForm();
                        frm.ShowDialog();
                        selected = frm.Color;
                    }
                    else
                    {
                        var rand = new Random();
                        selected = (CardColor)rand.Next(4); // здесь стратегия бота при выборе цвета
                    }
                    card.ChangeWildColor(selected);
                    UpdateAroundArrows(card);
                    Log.Add($"{PlayPlaces.GetPlayerName(stepOrder)} выбрал цвет: {selected}");
                    Log.Add($"{PlayPlaces.GetPlayerName(nextStepOrder)} берёт четыре карты и пропускает ход");
                    Helper.GetPurchaseCardToHands(nextStepOrder, 4);
                    PlayPlaces.AddOrSubCountCards(nextStepOrder, 4);
                    Game.NextStep();
                }
            }
        }

        // отрисовка карт из нашего словаря
        private void panelDirection_Paint(object sender, PaintEventArgs e)
        {
            if (TopCard == null || !Images.ContainsKey(TopCard.Name)) return;
            var g = e.Graphics;
            var image = Images[TopCard.Name];
            var srcRect = new Rectangle(0, 0, image.Width, image.Height);
            var kw = 1f * panelDirection.Width / image.Width;
            var kh = 1f * panelDirection.Height / image.Height;
            var newWidth = (kw < kh ? image.Width * kw : image.Width * kh) * 0.75f;
            var newHeight = (kw < kh ? image.Height * kw : image.Height * kh) * 0.75f;
            var destRect = new Rectangle((panelDirection.Width - (int)newWidth) / 2,
                (panelDirection.Height - (int)newHeight) / 2, (int)newWidth, (int)newHeight);
            g.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
        }

        // обработка нажатия кнопки Вид - Лог
        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer3.Panel2Collapsed = !showLogToolStripMenuItem.Checked;
        }

        // отображение кнопки UNO! и запуск таймера
        private void btnSayUnoIfOneCard_VisibleChanged(object sender, EventArgs e)
        {
            if (btnSayUnoIfOneCard.Visible)
                timerSayUNOwait.Enabled = true;
        }

        // нажали кнопку, отключаем таймер
        private void btnSayUnoIfOneCard_Click(object sender, EventArgs e)
        {
            timerSayUNOwait.Enabled = false;
            btnSayUnoIfOneCard.Visible = false;
            Log.Add($"{PlayPlaces.GetPlayerName(ThisOrder)} сказал: UNO!");
        }

        // не успели нажать, +2 карты
        private void timerSayUNOwait_Tick(object sender, EventArgs e)
        {
            timerSayUNOwait.Enabled = false;
            btnSayUnoIfOneCard.Visible = false;
            Log.Add($"{PlayPlaces.GetPlayerName(ThisOrder)} не успел сказать UNO и берёт две карты");
            Helper.GetPurchaseCardToHands(ThisOrder, 2);
            PlayPlaces.AddOrSubCountCards(ThisOrder, 2);
            UpdateHandsCards();
            PlayPlaces.Update();
        }

        // играть с ботами (кнопка)
        private void gameWithBotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ThisOrder == 1)
            {
                BotsMode = true;
                PurchaseDesk.ReshuffleCards();
                Game.RunGame();
                PlayPlaces.ClearScores();
                PlayPlaces.Update();
                TopCard = null;
                timerStepAsBot.Enabled = PlayPlaces.GetPlayerName(ThisOrder)?.StartsWith("Бот") ?? false;
            }
        }
    }
}
