using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw_10_lv_3_ex_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] riders_distance_traveled = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        // Initializing player with a rider
        Random rnd = new Random();
        int players_rider;
        private void btn_get_rider_Click(object sender, EventArgs e)
        {
            players_rider = rnd.Next(0, 10);
            lbl_assigned_rider.Text = $"Assigned rider: {players_rider + 1}";
            btn_get_rider.Enabled = false;
            btn_start_round.Enabled = true;
        }

        // Round initializer
        int round_counter = 0;
        private void btn_start_round_Click(object sender, EventArgs e)
        {
            if (!btn_get_rider.Enabled && round_counter < 5)
            {
                lbl_round_counter.Text = $"Round {round_counter + 1}";
                int winner = round_get_results(ref riders_distance_traveled);
                update_round_winner_score(winner);
                round_counter++;
            }
            if (round_counter == 5)
            {
                btn_start_round.Enabled = false;
                announce_winner();
            }
        }
        // Reset game
        private void btn_restart_Click(object sender, EventArgs e)
        {
            for (int rider = 0; rider < 10; rider++)
            {
                riders_distance_traveled[rider] = 0;
            }
            drop_progress_bars();
            reset_round_winner_score();
            round_counter = 0;
            lbl_winner.Text = "Winner: -";
            lbl_round_counter.Text = "Round: -";
            lbl_assigned_rider.Text = "Assigned rider: -";
            btn_get_rider.Enabled = true;
            btn_start_round.Enabled = false;
            players_rider = -1;
            lbl_player_win.Text = "";
        }
        public void announce_winner()
        {
            int[] scores = new int[10];
            // Get scores
            scores[0] = int.Parse(lbl_points_rider_0.Text);
            scores[1] = int.Parse(lbl_points_rider_1.Text);
            scores[2] = int.Parse(lbl_points_rider_2.Text);
            scores[3] = int.Parse(lbl_points_rider_3.Text);
            scores[4] = int.Parse(lbl_points_rider_4.Text);
            scores[5] = int.Parse(lbl_points_rider_5.Text);
            scores[6] = int.Parse(lbl_points_rider_6.Text);
            scores[7] = int.Parse(lbl_points_rider_7.Text);
            scores[8] = int.Parse(lbl_points_rider_8.Text);
            scores[9] = int.Parse(lbl_points_rider_9.Text);
            int biggest_score = scores[0], biggest_score_holder = 0;
            for (int rider = 0; rider < 10; rider++)
            {
                if (scores[rider] > biggest_score)
                {
                    biggest_score = scores[rider];
                    biggest_score_holder = rider;
                }
            }
            bool tie = false;
            for (int rider = 0; rider < 10; rider++)
            {
                if(biggest_score == scores[rider] && rider != biggest_score_holder)
                {
                    tie = true;
                }
            }
            if (!tie)
            {
                lbl_winner.Text = $"Winner: {biggest_score_holder + 1}";
                if (players_rider == biggest_score_holder)
                {
                    lbl_player_win.Text = "You win!";
                }
                else
                    lbl_player_win.Text = "Try again :)";
            }
            else
            {
                lbl_winner.Text = "Tie!";
                if (players_rider == biggest_score_holder)
                {
                    lbl_player_win.Text = "You kinda win..?";
                }
            }
        }
        
        public void update_round_winner_score(int winner_id)
        {
            int new_score;
            switch (winner_id)
            {
                case 0:
                    new_score = int.Parse(lbl_points_rider_0.Text) + 5;
                    lbl_points_rider_0.Text = new_score.ToString();
                    break;
                case 1:
                    new_score = int.Parse(lbl_points_rider_1.Text) + 5;
                    lbl_points_rider_1.Text = new_score.ToString();
                    break;
                case 2:
                    new_score = int.Parse(lbl_points_rider_2.Text) + 5;
                    lbl_points_rider_2.Text = new_score.ToString();
                    break;
                case 3:
                    new_score = int.Parse(lbl_points_rider_3.Text) + 5;
                    lbl_points_rider_3.Text = new_score.ToString();
                    break;
                case 4:
                    new_score = int.Parse(lbl_points_rider_4.Text) + 5;
                    lbl_points_rider_4.Text = new_score.ToString();
                    break;
                case 5:
                    new_score = int.Parse(lbl_points_rider_5.Text) + 5;
                    lbl_points_rider_5.Text = new_score.ToString();
                    break;
                case 6:
                    new_score = int.Parse(lbl_points_rider_6.Text) + 5;
                    lbl_points_rider_6.Text = new_score.ToString();
                    break;
                case 7:
                    new_score = int.Parse(lbl_points_rider_7.Text) + 5;
                    lbl_points_rider_7.Text = new_score.ToString();
                    break;
                case 8:
                    new_score = int.Parse(lbl_points_rider_8.Text) + 5;
                    lbl_points_rider_8.Text = new_score.ToString();
                    break;
                case 9:
                    new_score = int.Parse(lbl_points_rider_9.Text) + 5;
                    lbl_points_rider_9.Text = new_score.ToString();
                    break;
            }
        }
        public void reset_round_winner_score()
        {
        lbl_points_rider_0.Text = "0";
        lbl_points_rider_1.Text = "0";
        lbl_points_rider_2.Text = "0";
        lbl_points_rider_3.Text = "0";
        lbl_points_rider_4.Text = "0";
        lbl_points_rider_5.Text = "0";
        lbl_points_rider_6.Text = "0";
        lbl_points_rider_7.Text = "0";
        lbl_points_rider_8.Text = "0";
        lbl_points_rider_9.Text = "0";
        }
        public int round_get_results(ref int[] riders_distance_traveled)
        {
            int[] riders_distance_traveled_current = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int rider = 0; rider < 10; rider++)
            {
                if (rnd.Next(0, 10) != 0)
                    riders_distance_traveled_current[rider] = rnd.Next(1, 6);
            }
            int winner = riders_distance_traveled_current[0], winner_id = 0;
            for (int rider = 0; rider < 10; rider++)
            {
                if (riders_distance_traveled_current[rider] > winner)
                {
                    winner = riders_distance_traveled_current[rider];
                    winner_id = rider;
                }
            }
            for (int rider = 0; rider < 10; rider++)
            {
                riders_distance_traveled[rider] += riders_distance_traveled_current[rider];
            }
            update_progress_bars(riders_distance_traveled_current);
            return winner_id;
        }
        public void update_progress_bars(int[] progress)
        {
            pb_rider_0.Value += progress[0];
            pb_rider_1.Value += progress[1];
            pb_rider_2.Value += progress[2];
            pb_rider_3.Value += progress[3];
            pb_rider_4.Value += progress[4];
            pb_rider_5.Value += progress[5];
            pb_rider_6.Value += progress[6];
            pb_rider_7.Value += progress[7];
            pb_rider_8.Value += progress[8];
            pb_rider_9.Value += progress[9];
        }
        public void drop_progress_bars()
        {
            pb_rider_0.Value = 0;
            pb_rider_1.Value = 0;
            pb_rider_2.Value = 0;
            pb_rider_3.Value = 0;
            pb_rider_4.Value = 0;
            pb_rider_5.Value = 0;
            pb_rider_6.Value = 0;
            pb_rider_7.Value = 0;
            pb_rider_8.Value = 0;
            pb_rider_9.Value = 0;
        }
    }
}
