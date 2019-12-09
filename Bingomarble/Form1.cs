using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bingomarble
{
    public partial class Form1 : Form
    {

        // 땅 인덱스 번호
        int[,] num_land = new int[5, 5];
        int[] selected = new int[2];

        // 위치
        int location1 = 0,
            location2 = 0;
        bool player_turn = true,    // t=1,f=2
            upgraded = false;       // 업그레이드 클릭 여부

        Land[,] l = new Land[5, 5]; // 땅

        // 돈
        int money1 = 1000,
            money2 = 1000;

        // 소유한 땅
        int Land1 = 0,
            Land2 = 0;

        //////////////////////////////////////////////////////////////////////////////////////

        public Form1()
        {
            InitializeComponent();
        }



        //// 프로그램 실행화면
        private void Form1_Load(object sender, EventArgs e)
        {
            Land.Land_Load(l);  // 토지 정보 윈도우에 가져오기

            // 행과 열 생성
            for (int i = 0; i < 5; i++)
            {
                dataGridView1.Columns.Add("", "");
                dataGridView1.Rows.Add();
            }

            // 열 크기
            for (int nX = 0; nX < dataGridView1.ColumnCount; nX++)
            {
                dataGridView1.Columns[nX].Width = 100;
            }

            // 행 크기
            for (int nY = 0; nY < dataGridView1.RowCount; nY++)
            {
                dataGridView1.Rows[nY].Height = 100;
            }

            // 행, 열 번호 지정
            int count = 0;

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (i % 2 == 0)
                    {
                        switch (i)
                        {
                            case 0:
                                num_land[i, j] = j + 1;
                                dataGridView1.Rows[i].Cells[j].Value = l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent);
                                break;
                            case 2:
                                num_land[i, j] = j + 11;
                                dataGridView1.Rows[i].Cells[j].Value = l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent);
                                break;
                            case 4:
                                num_land[i, j] = j + 21;
                                dataGridView1.Rows[i].Cells[j].Value = l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent);
                                break;
                        }
                    }
                    else
                    {
                        switch (i)
                        {
                            case 1:
                                num_land[i, j] = 10 - j;
                                dataGridView1.Rows[i].Cells[j].Value = l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent);
                                break;
                            case 3:
                                num_land[i, j] = 20 - j;
                                dataGridView1.Rows[i].Cells[j].Value = l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent);
                                break;
                        }
                    }
                    count++;
                }
                buttonUpgrade.Enabled = false;      // 지역이 클릭될 때까지 비활성화
                Land_Information();   // 땅 정보 카드 초기화
                dataGridView1.ClearSelection();     // 초반 1번 칸 선택 방지
                dataGridView1.MultiSelect = false;  // 다중 선택 방지
                textBoxTurn.Text = "P1";
            }
        }



        //// 주사위 굴리기 클릭
        private void buttonDice_Click(object sender, EventArgs e)
        {
            // 주사위를 굴림
            Random randomValue = new Random();
            int dice = randomValue.Next(1, 7);

            textBoxDice.Text = dice.ToString();

            // P1 이동
            if (player_turn == true)
            {
                location1 += dice;
                if (location1 > 25)
                {
                    location1 -= 25;
                    money1 += 200;      // 출발점을 지남
                }

                // 위치 이동
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        move(i, j);
                    }
                }
                if (location1 == 5)
                    Snakeladder(l[1, 3], 0, 4, ref location1);
                else if (location1 == 11)
                    Snakeladder(l[4, 0], 2, 0, ref location1);
                else if (location1 == 22)
                    Snakeladder(l[3, 4], 4, 1, ref location1);

                player_turn = false; // 턴을 넘김
                if (player_turn)
                    textBoxTurn.Text = "P1";
                else textBoxTurn.Text = "P2";
                upgraded = false;
            }



            // P2 이동
            else
            {
                location2 += dice;

                if (location2 > 25)
                {
                    location2 -= 25;
                    money2 += 200;      // 출발점을 지남
                }


                // 위치 이동
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        move(i, j);
                    }
                }
                if (location2 == 5)
                    Snakeladder(l[1, 3], 0, 4, ref location2);
                else if (location2 == 11)
                    Snakeladder(l[4, 0], 2, 0, ref location2);
                else if (location2 == 22)
                    Snakeladder(l[3, 4], 4, 1, ref location2);

                player_turn = true; // 턴을 넘김
                if (player_turn)
                    textBoxTurn.Text = "P1";
                else textBoxTurn.Text = "P2";
                upgraded = false;
            }

            // 정보 출력
            textBoxP1_Location.Text = location1.ToString();
            textBoxP2_Location.Text = location2.ToString();
            textBoxP1_Money.Text = money1.ToString();
            textBoxP2_Money.Text = money2.ToString();

        }


        //// 말 이동 후 비워주기
        void move_empty(int i, int j)
        {
            if (i % 2 == 0)
            {
                switch (i)
                {
                    case 0:
                        dataGridView1.Rows[i].Cells[j].Value = l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent);
                        break;
                    case 2:
                        dataGridView1.Rows[i].Cells[j].Value = l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent);
                        break;
                    case 4:
                        dataGridView1.Rows[i].Cells[j].Value = l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent);
                        break;
                }
            }
            else
            {
                switch (i)
                {
                    case 1:
                        dataGridView1.Rows[i].Cells[j].Value = l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent);
                        break;
                    case 3:
                        dataGridView1.Rows[i].Cells[j].Value = l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent);
                        break;
                }
            }
        }


        //// 땅에 도착
        void Land_Arrival(Land ob)
        {

            switch (ob.Host)
            {
                // 주인 없는 땅에 도착
                case 0:
                    DialogResult res1 = MessageBox.Show(
                    "땅을 사시겠습니까?",
                    "주인 없는 땅에 도착",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                    if (res1 == DialogResult.Yes)
                    {
                        if (player_turn == true)
                        {
                            if (money1 >= ob.Price)
                            {
                                money1 -= ob.Price;
                                ob.Host = 1;
                                Land1++;
                                dataGridView1.Rows[ob.Row].Cells[ob.Cell].Style.BackColor = Color.LightBlue;
                                MessageBox.Show("땅을 구입하였습니다.", "구입");
                                Bingo(player_turn); // (체크) 빙고를 완성
                            }
                            else
                            {
                                MessageBox.Show("돈이 부족하여 땅을 구입할 수 없습니다.", "구입 실패");
                            }
                        }
                        else
                        {
                            if (money2 >= ob.Price)
                            {
                                money2 -= ob.Price;
                                ob.Host = 2;
                                Land2++;
                                dataGridView1.Rows[ob.Row].Cells[ob.Cell].Style.BackColor = Color.Yellow;
                                MessageBox.Show("땅을 구입하였습니다.", "구입");
                                Bingo(player_turn); // (체크) 빙고를 완성
                            }
                            else
                            {
                                MessageBox.Show("돈이 부족하여 땅을 구입할 수 없습니다.", "구입 실패");
                            }
                        }
                        textBoxP2_Money.Text = money2.ToString();
                    }
                    break;

                // P1이 땅에 도착
                case 1:
                    if (!player_turn)
                    {
                        DialogResult res2 = MessageBox.Show(
                                "임대료를 지불합니다.",
                                "P1의 땅에 도착");

                        // 0단계는 기본 임대료
                        if (ob.Level == 0)
                        {
                            if (money2 >= ob.Rent)
                            {
                                money2 -= ob.Rent;
                            }
                            else
                            {
                                MessageBox.Show("P2의 승리입니다.", "임대료 지불 불가");
                                Close();
                            }
                        }
                        // 1단계 이상 업그레이드 임대료
                        else
                        {
                            if (money2 >= ob.New_Price)
                            {
                                money2 -= ob.New_Price;
                            }
                            else
                            {
                                MessageBox.Show("P2의 승리입니다.", "임대료 지불 불가");
                                Close();
                            }
                        }
                    }
                    break;


                // P2의 땅에 도착
                case 2:
                    if (player_turn)
                    {
                        DialogResult res2 = MessageBox.Show(
                                "임대료를 지불합니다.",
                                "P1의 땅에 도착");

                        if (ob.Level == 0)
                        {
                            if (money1 >= ob.Rent)
                            {
                                money1 -= ob.Rent;
                            }
                            else
                            {
                                MessageBox.Show("P2의 승리입니다.", "임대료 지불 불가");
                                Close();
                            }
                        }
                        else
                        {
                            if (money1 >= ob.New_Price)
                            {
                                money1 -= ob.New_Price;
                            }
                            else
                            {
                                MessageBox.Show("P2의 승리입니다.", "임대료 지불 불가");
                                Close();
                            }
                        }
                    }
                    break;
            }
            Soldout(); // (체크) 땅을 모두 구입
        }


        //// 땅을 모두 구입한 경우
        void Soldout()
        {
            if ((Land1 + Land2) == (dataGridView1.RowCount * dataGridView1.ColumnCount))
            {
                if (Land1 > Land2)
                {
                    MessageBox.Show("P1의 땅이 많으므로 P1의 승리입니다.", "게임종료");
                    Close();
                }
                else if (Land1 < Land2)
                {
                    MessageBox.Show("P2의 땅이 많으므로 P2의 승리입니다.", "게임종료");
                    Close();
                }
            }
        }


        // 합의 하에 게임 종료
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(
                    "게임을 종료하시겠습니까?",
                    "합의되셨나요?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                if (Land1 > Land2)
                {
                    MessageBox.Show("P1의 땅이 많으므로 P1의 승리입니다.", "게임 마치기");
                    Close();
                }
                else if (Land1 < Land2)
                {
                    MessageBox.Show("P2의 땅이 많으므로 P2의 승리입니다.", "게임 마치기");
                    Close();
                }
                else
                {
                    MessageBox.Show("무승부입니다.", "게임 마치기");
                    Close();
                }
            }
        }


        // 지역 업그레이드
        private void buttonUpgrade_Click(object sender, EventArgs e)
        {
            if (player_turn && upgraded == false) // P1
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        // 조건 : P1차례 & 업그레이드 안함 & 소유한 토지 & Lv4 미만 = 업그레이드 가능
                        if (l[i, j].Host == 1 && dataGridView1.Rows[i].Cells[j].Selected && l[i, j].Level != 4)
                        {
                            Land_Upgrade(l[i, j]);
                            MessageBox.Show(l[i, j].Name + " 지역이 Level " + l[i, j].Level + "만큼 업그레이드 되었습니다.", "업그레이드 완료");
                            upgraded = true;
                        }
                        // 조건 불만족
                        else
                        {
                            if (l[i, j].Host != 1 && dataGridView1.Rows[i].Cells[j].Selected)
                                MessageBox.Show("소유한 땅이 아닙니다.", "업그레이드 실패");

                            else if (l[i, j].Level == 4 && dataGridView1.Rows[i].Cells[j].Selected)
                                MessageBox.Show("이미 업그레이드가 완료된 지역입니다.", "업그레이드 실패");
                        }
                    }
                }
            }

            else                                    // P2
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (l[i, j].Host == 2 && dataGridView1.Rows[i].Cells[j].Selected && l[i, j].Level != 4)
                        {
                            Land_Upgrade(l[i, j]);
                            MessageBox.Show(l[i, j].Name + " 지역이 Level " + l[i, j].Level + "만큼 업그레이드 되었습니다.", "업그레이드 완료");
                            upgraded = true;
                        }
                        else
                        {
                            if (l[i, j].Host != 2 && dataGridView1.Rows[i].Cells[j].Selected)
                                MessageBox.Show("소유한 땅이 아닙니다.", "업그레이드 실패");

                            else if (l[i, j].Level == 4 && dataGridView1.Rows[i].Cells[j].Selected)
                                MessageBox.Show("이미 업그레이드가 완료된 지역입니다.", "업그레이드 실패");
                        }
                    }
                }
            }
        }


        // 토지 업그레이드
        private void Land_Upgrade(Land ob)
        {
            // P1
            if (player_turn)
            {
                switch (ob.Level) // Lv0=기본, Lv1>=업그레이드
                {
                    case 0:
                        ob.Level++;
                        ob.New_Price += ob.Rent + 5;
                        money1 -= ob.Upgrade_pay;

                        break;
                    case 1:
                        ob.Level++;
                        ob.New_Price += 5;
                        money1 -= ob.Upgrade_pay;
                        break;
                    case 2:
                        ob.Level++;
                        ob.New_Price += 5;
                        money1 -= ob.Upgrade_pay;
                        break;
                    case 3:
                        ob.Level++;
                        ob.New_Price += 15;
                        ob.Upgrade_pay = 40;
                        money1 -= ob.Upgrade_pay;
                        break;
                    case 4:
                        MessageBox.Show("더 이상 업그레이드할 수 없습니다.", "만렙"); // 호텔
                        break;
                }
            }
            else
            {
                switch (ob.Level)
                {
                    case 0:
                        ob.Level++;
                        ob.New_Price += ob.Rent + 5;
                        money2 -= ob.Upgrade_pay;
                        break;
                    case 1:
                        ob.Level++;
                        ob.New_Price += 5;
                        money2 -= ob.Upgrade_pay;
                        break;
                    case 2:
                        ob.Level++;
                        ob.New_Price += 5;
                        money2 -= ob.Upgrade_pay;
                        break;
                    case 3:
                        ob.Level++;
                        ob.New_Price += 15;
                        ob.Upgrade_pay = 40;
                        money2 -= ob.Upgrade_pay;
                        break;
                    case 4:
                        MessageBox.Show("더 이상 업그레이드할 수 없습니다.", "만렙");
                        break;
                }
            }
            textBoxP1_Money.Text = money1.ToString();
            textBoxP2_Money.Text = money2.ToString();
            buttonUpgrade.Enabled = false;      // 업그레이드를 한 번 누르면 비활성화
        }



        //// 말의 이동
        void move(int i, int j)
        {
            // P1
            if (player_turn == true)
            {
                // P1 말이 셀을 벗어나는 경우
                if (dataGridView1.Rows[i].Cells[j].Value.Equals(l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent) + "★"))
                {
                    move_empty(i, j);
                }
                // 동시에 있을 때 벗어나는 경우
                else if (dataGridView1.Rows[i].Cells[j].Value.Equals(l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent) + "☆★")
                || dataGridView1.Rows[i].Cells[j].Value.Equals(l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent) + "★☆"))
                {
                    move_empty(i, j);
                    dataGridView1.Rows[i].Cells[j].Value += "☆";
                }

                // 이동
                if (num_land[i, j] == location1)
                {
                    dataGridView1.Rows[i].Cells[j].Value += "★";
                    Land_Arrival(l[i, j]);
                }
            }

            // P2
            else
            {
                // P2 말이 셀을 벗어나는 경우
                if (dataGridView1.Rows[i].Cells[j].Value.Equals(l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent) + "☆"))
                {
                    move_empty(i, j);
                }
                // 두 말이 동시에 있는 경우
                else if (dataGridView1.Rows[i].Cells[j].Value.Equals(l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent) + "☆★")
                || dataGridView1.Rows[i].Cells[j].Value.Equals(l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent) + "★☆"))
                {
                    move_empty(i, j);
                    dataGridView1.Rows[i].Cells[j].Value += "★";
                }

                // 이동
                if (num_land[i, j] == location2)
                {
                    dataGridView1.Rows[i].Cells[j].Value += "☆";
                    Land_Arrival(l[i, j]);
                }
            }
        }



        // 셀을 클릭해서 업그레이드 활성화
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (player_turn && upgraded == false)                                                           // P1 + 업그레이드 x
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Selected)                                        // 선택된 셀 중에
                        {
                            if (dataGridView1.Rows[i].Cells[j].Style.BackColor == Color.LightBlue)          // 자기 색깔을 눌렀을 때만 활성화
                                selected[0] = i; selected[1] = j;
                            buttonUpgrade.Enabled = true;
                        }
                    }
                }
                if (upgraded == true && dataGridView1.Rows[selected[0]].Cells[selected[1]].Style.BackColor != Color.LightBlue)          // 자기 셀을 선택 + 업그레이드가 완료 = 비활성화
                    buttonUpgrade.Enabled = false;
            }

            // P2
            else if (!player_turn && upgraded == false)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Selected)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Style.BackColor == Color.Yellow)
                            {
                                buttonUpgrade.Enabled = true;
                            }
                        }
                    }
                }
                if (upgraded == true && dataGridView1.Rows[selected[0]].Cells[selected[1]].Style.BackColor != Color.Yellow)
                    buttonUpgrade.Enabled = false;
            }
        }


        // 뱀 사다리
        void Snakeladder(Land ob, int i, int j, ref int location)
        {
            // P1
            if (player_turn == true)
            {
                switch (location)                                       // 뱀사다리는 미리 위치를 정함
                {
                    case 5:
                        MessageBox.Show("5번 ---> 7번", "뱀사다리");
                        if (dataGridView1.Rows[i].Cells[j].Value.Equals(l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent) + "★"))
                        {
                            move_empty(i, j);
                            dataGridView1.Rows[1].Cells[3].Value += "★";
                        }
                        location1 = 7;
                        if (ob.Host == 2)
                        {
                            Land_Arrival(l[1, 3]);
                        }
                        break;
                    case 11:
                        MessageBox.Show("11번 ---> 21번", "뱀사다리");
                        if (dataGridView1.Rows[i].Cells[j].Value.Equals(l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent) + "★"))
                        {
                            move_empty(i, j);
                            dataGridView1.Rows[4].Cells[0].Value += "★";
                        }
                        location1 = 21;
                        if (ob.Host == 2)
                        {
                            Land_Arrival(l[4, 0]);
                        }
                        break;
                    case 22:
                        MessageBox.Show("22번 ---> 16번", "뱀사다리");
                        if (dataGridView1.Rows[i].Cells[j].Value.Equals(l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent) + "★"))
                        {
                            move_empty(i, j);
                            dataGridView1.Rows[3].Cells[4].Value += "★";
                        }
                        location1 = 16;
                        if (ob.Host == 2)
                        {
                            Land_Arrival(l[3, 4]);
                        }
                        break;
                }
            }

            // P2
            else
            {
                switch (location)
                {
                    case 5:
                        MessageBox.Show("5번 ---> 7번", "뱀사다리");
                        if (dataGridView1.Rows[i].Cells[j].Value.Equals(l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent) + "☆"))
                        {
                            move_empty(i, j);
                            dataGridView1.Rows[1].Cells[3].Value += "☆";
                        }
                        location2 = 7;
                        if (ob.Host == 1)
                        {
                            Land_Arrival(l[1, 3]);
                        }
                        break;
                    case 11:
                        MessageBox.Show("11번 ---> 21번", "뱀사다리");
                        if (dataGridView1.Rows[i].Cells[j].Value.Equals(l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent) + "☆"))
                        {
                            move_empty(i, j);
                            dataGridView1.Rows[4].Cells[0].Value += "☆";
                        }
                        location2 = 21;
                        if (ob.Host == 1)
                        {
                            Land_Arrival(l[4, 0]);
                        }
                        break;
                    case 22:
                        MessageBox.Show("22번 ---> 16번", "뱀사다리");
                        if (dataGridView1.Rows[i].Cells[j].Value.Equals(l[i, j].Land_Inform(num_land[i, j], l[i, j].Name + "\n", l[i, j].Price, l[i, j].Rent) + "☆"))
                        {
                            move_empty(i, j);
                            dataGridView1.Rows[3].Cells[4].Value += "☆";
                        }
                        location2 = 16;
                        if (ob.Host == 1)
                        {
                            Land_Arrival(l[3, 4]);
                        }
                        break;
                }
            }
            textBoxP1_Location.ToString();
            textBoxP2_Location.ToString();
        }


        //// 빙고!
        void Bingo(bool player_turns)
        {
            int Bingo = 0;

            // 플레이어 번호 (= 1, P2 = 2)
            int p = 0;
            if (player_turns)
                p = 1;
            else
                p = 2;


            // 가로 빙고
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (l[i, j].Host == p)
                        Bingo++;
                }

                if (Bingo == 5)
                {
                    MessageBox.Show("P" + p + "의 가로 빙고가 완성되어 P" + p + "의 승리입니다.", "빙고!");
                    Close();
                }
                else
                {
                    Bingo = 0;
                }
            }

            // 세로 빙고
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (l[j, i].Host == p)
                        Bingo++;
                }

                if (Bingo == 5)
                {
                    MessageBox.Show("P" + p + "의 세로 빙고가 완성되어 P" + p + "의 승리입니다.", "빙고!");
                    Close();
                }
                else
                {
                    Bingo = 0;
                }
            }

            // 대각선 빙고
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                if (l[i, i].Host == p)
                    Bingo++;
            }
            if (Bingo == 5)
            {
                MessageBox.Show("P" + p + "의 대각선 빙고가 완성되어 P" + p + "의 승리입니다.", "빙고!");
                Close();
            }
            else
            {
                Bingo = 0;
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (l[i, 4 - i].Host == p)
                    Bingo++;
            }
            if (Bingo == 5)
            {
                MessageBox.Show("P" + p + "의 대각선 빙고가 완성되어 P" + p + "의 승리입니다.", "빙고!");
                Close();
            }
            else
            {
                Bingo = 0;
            }
        }



        // 땅 정보 카드 업데이트
        void Land_Information()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Selected)
                    {
                        buttonUpgrade.Enabled = true;
                        textBoxInformation.Text = l[i, j].Number + ". " + l[i, j].Name + Environment.NewLine + Environment.NewLine
                            + "토지가격 :  " + l[i, j].Price + Environment.NewLine
                            + "임대료 :     " + l[i, j].Rent + Environment.NewLine + Environment.NewLine
                            + "주택 1개 :   " + (l[i, j].Rent + 5) + "  (20)" + Environment.NewLine
                            + "주택 2개 :   " + (l[i, j].Rent + 10) + "  (20)" + Environment.NewLine
                            + "주택 3개 :   " + (l[i, j].Rent + 15) + "  (20)" + Environment.NewLine
                            + "호텔 1개 :   " + (l[i, j].Rent + 30) + "  (40)" + Environment.NewLine + Environment.NewLine;
                    }
                    textBoxInformation.Text += Environment.NewLine + Environment.NewLine + "(숫자)는 비용";
                }
            }
        }
    }
}
