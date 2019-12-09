using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Bingomarble
{
    class Land
    {
        public String Name; // 지역
        public int Number,  // 지역 번호
            Price,         // 토지 가격
            Rent,          // 기본 임대료
            Level,      // 주택
            Host,       // Host = 땅 주인(없음 = 0, P1 = 1, P2 = 2)
            Row,        // 가로 행 번호
            Cell,       // 세로 열 번호
            Ladder,     // 뱀사다리 여부
            Upgrade_pay,     // 업그레이드 비용
            New_Price;  // 업그레이드 임대료
            

        public Land()
        {
            Name = "";
            Number = 0;
            Price = 0;
            Rent = 0;
            Level = 0;
            Host = 0;
            Row = 0;
            Cell = 0;
            Ladder = 0;
            Upgrade_pay = 20;
            New_Price = 0;
        }

        public Land(int Number, int Row, int Cell, String Name, int Price, int Rent,
            int Ladder, int Upgrade_pay = 20, int Level = 0, int Host = 0, int New_Price = 0)
        {
            this.Level = Level;
            this.Upgrade_pay = Upgrade_pay;
            this.Number = Number;
            this.Row = Row;
            this.Cell = Cell;
            this.Name = Name;
            this.Price = Price;
            this.Rent = Rent;
            this.Ladder = Ladder;
            this.Host = Host;
            this.New_Price = New_Price;
        }


        // 토지 정보 셀에 보이기
        public Object Land_Inform(int num, String Name, int Price, int Rent)
        {
            return num + "\n" + Name + "가격:" + Price + "\n" + "임대료:" + Rent + "\n";
        }
        

        // 토지 정보 로드
        public static void Land_Load(Object[,] ob)
        {
            ob[0, 0] = new Land(1,0, 0, "서울", 100, 10, 0);      // 디폴트 초기화한 매개변수는 생략
            ob[0, 1] = new Land(2,0, 1, "의정부", 100, 10, 0);
            ob[0, 2] = new Land(3,0, 2, "인천", 100, 10, 0);
            ob[0, 3] = new Land(4,0, 3, "대전", 100, 10, 0);
            ob[0, 4] = new Land(5,0, 4, "전주", 100, 10, 1);
            ob[1, 4] = new Land(6,1, 4, "광주", 100, 10, 0);
            ob[1, 3] = new Land(7,1, 3, "부산", 100, 10, 0);
            ob[1, 2] = new Land(8,1, 2, "대구", 100, 10, 0);
            ob[1, 1] = new Land(9,1, 1, "울산", 100, 10, 0);
            ob[1, 0] = new Land(10,1, 0, "포항", 100, 10, 0);
            ob[2, 0] = new Land(11,2, 0, "경주", 100, 10, 1);
            ob[2, 1] = new Land(12,2, 1, "춘천", 100, 10, 0);
            ob[2, 2] = new Land(13,2, 2, "목포", 100, 10, 0);
            ob[2, 3] = new Land(14,2, 3, "강릉", 100, 10, 0);
            ob[2, 4] = new Land(15,2, 4, "파주", 100, 10, 0);
            ob[3, 4] = new Land(16,3, 4, "청주", 100, 10, 0);
            ob[3, 3] = new Land(17,3, 3, "공주", 100, 10, 0);
            ob[3, 2] = new Land(18,3, 2, "밀양", 100, 10, 0);
            ob[3, 1] = new Land(19,3, 1, "진주", 100, 10, 0);
            ob[3, 0] = new Land(20,3, 0, "제주", 100, 10, 0);
            ob[4, 0] = new Land(21,4, 0, "충주", 100, 10, 0);
            ob[4, 1] = new Land(22,4, 1, "원주", 100, 10, 1);
            ob[4, 2] = new Land(23,4, 2, "완주", 100, 10, 0);
            ob[4, 3] = new Land(24,4, 3, "보령", 100, 10, 0);
            ob[4, 4] = new Land(25,4, 4, "김해", 100, 10, 0);
        }
    }
}