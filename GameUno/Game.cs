using MySql.Data.MySqlClient;


namespace GameUno
{
    public static class Game
    {
        private static int stepOrder;
        private static bool direction;
        private static bool run;
        public static int PlaceCount { get; private set; } = 2;
        public static int TargetScore { get; private set; } = 500;

        public static int Round { get; set; }

        // Очистить игру целиком
        public static void Clear()
        {
            Round = 0;
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    var tr = server.Connection.BeginTransaction();
                    try
                    {
                        using (var command = new MySqlCommand("DELETE FROM `Game`", server.Connection, tr))
                        {
                            command.ExecuteNonQuery();
                        }
                        using (var command = new MySqlCommand("INSERT INTO `Game` (`StepOrder`,`Direction`,`Run`)" +
                            " VALUES (@StepOrder,@Direction,@Run)",
                            server.Connection, tr))
                        {
                            command.Parameters.AddWithValue("@StepOrder", 0);
                            command.Parameters.AddWithValue("@Direction", false);
                            command.Parameters.AddWithValue("@Run", false);
                            command.ExecuteNonQuery();
                        }
                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                    }
                }
            }
        }

        public static void Update()
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    using (var command = new MySqlCommand(
                        "SELECT `StepOrder`,`Direction`,`Run` FROM `Game` LIMIT 1",
                        server.Connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SetStepOrder(reader.GetInt32(0));
                                SetDirection(reader.GetBoolean(1));
                                SetRun(reader.GetBoolean(2));
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void SetStepOrder(int order)
        {
            if (stepOrder == order) return;
            stepOrder = order;
            StepOrderChanged?.Invoke(stepOrder, EventArgs.Empty);
        }

        public static void ReverseDirection()
        {
            SetDirection(!direction);
        }

        private static void SetDirection(bool dir)
        {
            if (direction == dir) return;
            direction = dir;
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    using (var command = new MySqlCommand("UPDATE `Game` SET `Direction`=@Direction", server.Connection))
                    {
                        command.Parameters.AddWithValue("@Direction", direction);
                        command.ExecuteNonQuery();
                    }
                }
            }
            DirectionChanged?.Invoke(direction, EventArgs.Empty);
        }

        private static void SetRun(bool r)
        {
            if (run == r) return;
            run = r;
            RunChanged?.Invoke(run, EventArgs.Empty);
        }

        public static int GetPrevStepOrder(int stepOrder)
        {
            int step;
            if (Direction)
            {
                step = stepOrder;
                step++;
                if (step > PlaceCount)
                    step = 1;
            }
            else
            {
                step = stepOrder;
                step--;
                if (step == 0)
                    step = PlaceCount;
            }
            return step;
        }

        public static void PrevStep()
        {
            if (!run) return;
            StepOrder = GetPrevStepOrder(StepOrder);
        }

        public static int GetNextStepOrder(int stepOrder)
        {
            int step;
            if (!Direction)
            {
                step = stepOrder;
                step++;
                if (step > PlaceCount)
                    step = 1;
            }
            else
            {
                step = stepOrder;
                step--;
                if (step == 0)
                    step = PlaceCount;
            }
            return step;
        }

        public static void NextStep()
        {
            if (!run) return;
            StepOrder = GetNextStepOrder(StepOrder);
        }

        public static void StopGame()
        {
            Run = false;
        }

        public static void RunGame()
        {
            Round = 1;
            Run = true;
        }

        public static event EventHandler? StepOrderChanged;
        public static int StepOrder
        {
            get
            {
                using (var server = new Server())
                {
                    if (server.Connected)
                    {
                        using (var command = new MySqlCommand("SELECT `StepOrder` FROM `Game`", server.Connection))
                        {
                            stepOrder = (int)command.ExecuteScalar();
                            return stepOrder;
                        }
                    }
                }
                return 1;
            }
            set
            {
                stepOrder = value;
                using (var server = new Server())
                {
                    if (server.Connected)
                    {
                        using (var command = new MySqlCommand("UPDATE `Game` SET `StepOrder`=@StepOrder", server.Connection))
                        {
                            command.Parameters.AddWithValue("@StepOrder", stepOrder);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                StepOrderChanged?.Invoke(stepOrder, EventArgs.Empty);
            }
        }

        public static event EventHandler? DirectionChanged;
        public static bool Direction
        {
            get => direction;
            private set
            {
                if (direction == value) return;
                direction = value;
                DirectionChanged?.Invoke(direction, EventArgs.Empty);
            }
        }

        public static event EventHandler? RunChanged;
        public static bool Run
        {
            get => run;
            private set
            {
                if (run == value) return;
                run = value;
                using (var server = new Server())
                {
                    if (server.Connected)
                    {
                        using (var command = new MySqlCommand($"UPDATE `Game` SET `StepOrder`=@StepOrder,`Run`=@Run", server.Connection))
                        {
                            command.Parameters.AddWithValue("@StepOrder", 1);
                            command.Parameters.AddWithValue("@Run", run);
                            command.ExecuteNonQuery();
                        }
                        if (run)
                        {
                            Helper.EmptyHands();
                            PurchaseDesk.ReshuffleCards();
                            GetPurchaseCardToHands();
                        }
                    }
                }
                RunChanged?.Invoke(run, EventArgs.Empty);
            }
        }

        public static void GetPurchaseCardToHands()
        {
            for (var i = 1; i <= PlaceCount; i++)
            {
                Helper.GetPurchaseCardToHands(i, 7);
                PlayPlaces.SetCountCards(i, 7);
            }
        }

    }
}
