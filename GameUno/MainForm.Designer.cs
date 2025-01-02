namespace GameUno
{
    partial class MainForm
    {
        // Обязательная переменная конструктора.
        private System.ComponentModel.IContainer components = null;

        // Освободить все используемые ресурсы.
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameWithBotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.connectToGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runTheGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTheGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbPurchaseCardsCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSayUnoIfOneCard = new System.Windows.Forms.Button();
            this.btnGetACardFromPurchase = new System.Windows.Forms.Button();
            this.lvPlayers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.panelDirection = new System.Windows.Forms.Panel();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.lvCards = new System.Windows.Forms.ListView();
            this.imageListCards = new System.Windows.Forms.ImageList(this.components);
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.timerErrorStatus = new System.Windows.Forms.Timer(this.components);
            this.timerSayUNOwait = new System.Windows.Forms.Timer(this.components);
            this.timerStepAsBot = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(874, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearGameToolStripMenuItem,
            this.gameWithBotsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.connectToGameToolStripMenuItem,
            this.runTheGameToolStripMenuItem,
            this.stopTheGameToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.gameToolStripMenuItem.Text = "Файл";
            this.gameToolStripMenuItem.DropDownOpening += new System.EventHandler(this.gameToolStripMenuItem_DropDownOpening);
            // 
            // clearGameToolStripMenuItem
            // 
            this.clearGameToolStripMenuItem.Name = "clearGameToolStripMenuItem";
            this.clearGameToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.clearGameToolStripMenuItem.Text = "Очистить";
            this.clearGameToolStripMenuItem.Click += new System.EventHandler(this.clearGameToolStripMenuItem_Click);
            // 
            // gameWithBotsToolStripMenuItem
            // 
            this.gameWithBotsToolStripMenuItem.Name = "gameWithBotsToolStripMenuItem";
            this.gameWithBotsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.gameWithBotsToolStripMenuItem.Text = "Игра с ботами";
            this.gameWithBotsToolStripMenuItem.Click += new System.EventHandler(this.gameWithBotsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(199, 6);
            // 
            // connectToGameToolStripMenuItem
            // 
            this.connectToGameToolStripMenuItem.Name = "connectToGameToolStripMenuItem";
            this.connectToGameToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.connectToGameToolStripMenuItem.Text = "Подключиться";
            this.connectToGameToolStripMenuItem.Click += new System.EventHandler(this.connectToGameToolStripMenuItem_Click);
            // 
            // runTheGameToolStripMenuItem
            // 
            this.runTheGameToolStripMenuItem.Name = "runTheGameToolStripMenuItem";
            this.runTheGameToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.runTheGameToolStripMenuItem.Text = "Начать игру";
            this.runTheGameToolStripMenuItem.Click += new System.EventHandler(this.runTheGameToolStripMenuItem_Click);
            // 
            // stopTheGameToolStripMenuItem
            // 
            this.stopTheGameToolStripMenuItem.Name = "stopTheGameToolStripMenuItem";
            this.stopTheGameToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.stopTheGameToolStripMenuItem.Text = "Остановить игру";
            this.stopTheGameToolStripMenuItem.Click += new System.EventHandler(this.stopTheGameToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(199, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLogToolStripMenuItem});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.viewToolStripMenuItem.Text = "Вид";
            // 
            // showLogToolStripMenuItem
            // 
            this.showLogToolStripMenuItem.Checked = true;
            this.showLogToolStripMenuItem.CheckOnClick = true;
            this.showLogToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showLogToolStripMenuItem.Name = "showLogToolStripMenuItem";
            this.showLogToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.showLogToolStripMenuItem.Text = "Лог";
            this.showLogToolStripMenuItem.Click += new System.EventHandler(this.showLogToolStripMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getCardToolStripMenuItem});
            this.actionsToolStripMenuItem.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.actionsToolStripMenuItem.Text = "Действия";
            // 
            // getCardToolStripMenuItem
            // 
            this.getCardToolStripMenuItem.Enabled = false;
            this.getCardToolStripMenuItem.Name = "getCardToolStripMenuItem";
            this.getCardToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.getCardToolStripMenuItem.Text = "Взять карту";
            this.getCardToolStripMenuItem.Click += new System.EventHandler(this.btnGetACardFromPurchase_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatusMessage});
            this.statusStrip1.Location = new System.Drawing.Point(20, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(874, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslStatusMessage
            // 
            this.tsslStatusMessage.Name = "tsslStatusMessage";
            this.tsslStatusMessage.Size = new System.Drawing.Size(859, 17);
            this.tsslStatusMessage.Spring = true;
            this.tsslStatusMessage.Text = "(статус)";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(20, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvCards);
            this.splitContainer1.Size = new System.Drawing.Size(874, 505);
            this.splitContainer1.SplitterDistance = 295;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(874, 295);
            this.splitContainer2.SplitterDistance = 246;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lvPlayers, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(246, 295);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbPurchaseCardsCount);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSayUnoIfOneCard);
            this.panel1.Controls.Add(this.btnGetACardFromPurchase);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 231);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 61);
            this.panel1.TabIndex = 0;
            // 
            // lbPurchaseCardsCount
            // 
            this.lbPurchaseCardsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbPurchaseCardsCount.AutoSize = true;
            this.lbPurchaseCardsCount.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPurchaseCardsCount.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lbPurchaseCardsCount.Location = new System.Drawing.Point(155, 4);
            this.lbPurchaseCardsCount.Name = "lbPurchaseCardsCount";
            this.lbPurchaseCardsCount.Size = new System.Drawing.Size(17, 16);
            this.lbPurchaseCardsCount.TabIndex = 4;
            this.lbPurchaseCardsCount.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.SlateGray;
            this.label4.Location = new System.Drawing.Point(6, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Всего карт в колоде:";
            // 
            // btnSayUnoIfOneCard
            // 
            this.btnSayUnoIfOneCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSayUnoIfOneCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSayUnoIfOneCard.FlatAppearance.BorderSize = 0;
            this.btnSayUnoIfOneCard.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSayUnoIfOneCard.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSayUnoIfOneCard.Location = new System.Drawing.Point(111, 28);
            this.btnSayUnoIfOneCard.Name = "btnSayUnoIfOneCard";
            this.btnSayUnoIfOneCard.Size = new System.Drawing.Size(65, 30);
            this.btnSayUnoIfOneCard.TabIndex = 2;
            this.btnSayUnoIfOneCard.Text = "UNO!";
            this.btnSayUnoIfOneCard.UseVisualStyleBackColor = true;
            this.btnSayUnoIfOneCard.Visible = false;
            this.btnSayUnoIfOneCard.VisibleChanged += new System.EventHandler(this.btnSayUnoIfOneCard_VisibleChanged);
            this.btnSayUnoIfOneCard.Click += new System.EventHandler(this.btnSayUnoIfOneCard_Click);
            // 
            // btnGetACardFromPurchase
            // 
            this.btnGetACardFromPurchase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetACardFromPurchase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetACardFromPurchase.FlatAppearance.BorderSize = 0;
            this.btnGetACardFromPurchase.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGetACardFromPurchase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGetACardFromPurchase.Location = new System.Drawing.Point(3, 28);
            this.btnGetACardFromPurchase.Name = "btnGetACardFromPurchase";
            this.btnGetACardFromPurchase.Size = new System.Drawing.Size(102, 30);
            this.btnGetACardFromPurchase.TabIndex = 2;
            this.btnGetACardFromPurchase.Text = "Взять карту";
            this.btnGetACardFromPurchase.UseVisualStyleBackColor = true;
            this.btnGetACardFromPurchase.Visible = false;
            this.btnGetACardFromPurchase.Click += new System.EventHandler(this.btnGetACardFromPurchase_Click);
            // 
            // lvPlayers
            // 
            this.lvPlayers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvPlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPlayers.Enabled = false;
            this.lvPlayers.ForeColor = System.Drawing.Color.Black;
            this.lvPlayers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvPlayers.HideSelection = false;
            this.lvPlayers.Location = new System.Drawing.Point(3, 25);
            this.lvPlayers.MultiSelect = false;
            this.lvPlayers.Name = "lvPlayers";
            this.lvPlayers.Size = new System.Drawing.Size(240, 200);
            this.lvPlayers.TabIndex = 0;
            this.lvPlayers.UseCompatibleStateImageBehavior = false;
            this.lvPlayers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Игроки";
            this.columnHeader1.Width = 119;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Карты";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Очки";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(240, 16);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Игроки";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.SlateGray;
            this.label2.Location = new System.Drawing.Point(123, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Карты";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.SlateGray;
            this.label3.Location = new System.Drawing.Point(182, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Очки";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.panelDirection);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tbLog);
            this.splitContainer3.Size = new System.Drawing.Size(624, 295);
            this.splitContainer3.SplitterDistance = 339;
            this.splitContainer3.TabIndex = 0;
            this.splitContainer3.TabStop = false;
            // 
            // panelDirection
            // 
            this.panelDirection.AllowDrop = true;
            this.panelDirection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDirection.Location = new System.Drawing.Point(0, 0);
            this.panelDirection.Name = "panelDirection";
            this.panelDirection.Size = new System.Drawing.Size(339, 295);
            this.panelDirection.TabIndex = 0;
            this.panelDirection.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDirection_Paint);
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.Color.SlateGray;
            this.tbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Location = new System.Drawing.Point(0, 0);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.Size = new System.Drawing.Size(281, 295);
            this.tbLog.TabIndex = 10;
            // 
            // lvCards
            // 
            this.lvCards.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvCards.BackgroundImageTiled = true;
            this.lvCards.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvCards.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCards.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvCards.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lvCards.HideSelection = false;
            this.lvCards.LargeImageList = this.imageListCards;
            this.lvCards.Location = new System.Drawing.Point(0, 0);
            this.lvCards.MultiSelect = false;
            this.lvCards.Name = "lvCards";
            this.lvCards.ShowGroups = false;
            this.lvCards.Size = new System.Drawing.Size(874, 206);
            this.lvCards.TabIndex = 0;
            this.lvCards.UseCompatibleStateImageBehavior = false;
            this.lvCards.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvCards_MouseDoubleClick);
            // 
            // imageListCards
            // 
            this.imageListCards.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListCards.ImageSize = new System.Drawing.Size(80, 120);
            this.imageListCards.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timerUpdate
            // 
            this.timerUpdate.Enabled = true;
            this.timerUpdate.Interval = 1000;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // timerErrorStatus
            // 
            this.timerErrorStatus.Interval = 3000;
            this.timerErrorStatus.Tick += new System.EventHandler(this.timerErrorStatus_Tick);
            // 
            // timerSayUNOwait
            // 
            this.timerSayUNOwait.Interval = 3000;
            this.timerSayUNOwait.Tick += new System.EventHandler(this.timerSayUNOwait_Tick);
            // 
            // timerStepAsBot
            // 
            this.timerStepAsBot.Interval = 1;
            this.timerStepAsBot.Tick += new System.EventHandler(this.timerStepAsBot_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 551);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра \"UNO\"";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToGameToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView lvPlayers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem runTheGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopTheGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGetACardFromPurchase;
        private System.Windows.Forms.ImageList imageListCards;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListView lvCards;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelDirection;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatusMessage;
        private System.Windows.Forms.Timer timerErrorStatus;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getCardToolStripMenuItem;
        private System.Windows.Forms.Button btnSayUnoIfOneCard;
        private System.Windows.Forms.Timer timerSayUNOwait;
        private System.Windows.Forms.Label lbPurchaseCardsCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem gameWithBotsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Timer timerStepAsBot;
    }
}