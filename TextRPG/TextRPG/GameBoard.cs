using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace TextRPG
{
    /* 게임 보드 클래스 */
    internal class GameBoard
    {
        static void Main(string[] args)
        {
            Scenes scenes = new Scenes();   // Scenes 클래스 인스턴스화


            scenes.Scene_MakeCharacter();    // 캐릭터 생성 씬 실행

            Console.Clear();
            scenes.Scene_Main();             // 게임 시작 씬 실행

        }
    }

    /* 장면 관리 클래스 */
    public class Scenes
    {
        private PlayerStatus playerStatus;      // 스텟 클래스 필드 선언
        System_Shop system_Shop = new System_Shop();    // 상점 클래스 인스턴스화


        public string InputRemote()       // 중복되는 인풋 코드를 메서드화
        {
            Console.Write("\n>> ");
            return Console.ReadLine();
        }

        public void WrongInput()        // 잘못된 입력 문구 출력
        {
            Console.Clear();
            Console.WriteLine("<<올바른 값을 입력해주세요.>>\n");
        }

        // 캐릭터 생성 씬 //
        public void Scene_MakeCharacter()
        {
            playerStatus = new PlayerStatus();

            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.Write("원하시는 이름을 설정해주세요. \n\n>> ");
            playerStatus.name = Console.ReadLine();     // 이름 결정
            Console.WriteLine($"\n입력하신 이름은 {playerStatus.name} 입니다.\n");

            while (true)    // 올바른 값 입력할 때 까지 무한 루프
            {
                Console.WriteLine("원하시는 직업을 설정해주세요.");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 도적");

                string input = InputRemote();

                switch (input)       // 직업 결정
                {
                    case "1":
                        playerStatus.job = "전사";
                        break;

                    case "2":
                        playerStatus.job = "도적";
                        break;

                    default:
                        WrongInput();
                        continue;
                }
                break;
            }
        }

        // 게임 시작 (메인화면) 씬 //
        public void Scene_Main()
        {
            while (true)
            {
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");

                string input = InputRemote();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Scene_Status();
                        break;

                    case "2":
                        Console.Clear();
                        Scene_Inventory();
                        break;

                    case "3":
                        Console.Clear();
                        Scene_Shop();
                        break;

                    default:
                        WrongInput();
                        continue;
                }
            }

        }

        // 상태 보기 씬 //
        public void Scene_Status()
        {
            while (true)
            {
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

                Console.WriteLine($"Lv. {playerStatus.lv}");
                Console.WriteLine($"{playerStatus.name} ( {playerStatus.job} )");
                Console.WriteLine($"공격력 : {playerStatus.atk}");
                Console.WriteLine($"방어력 : {playerStatus.def}");
                Console.WriteLine($"체  력 : {playerStatus.hp}");
                Console.WriteLine($"Gold   : {playerStatus.gold}");

                Console.WriteLine("\n0. 나가기");

                string input = InputRemote();

                switch (input)
                {
                    case "0":
                        Console.Clear();
                        Scene_Main();
                        break;

                    default:
                        WrongInput();
                        continue;
                }
            }

        }

        // 인벤토리 씬
        public void Scene_Inventory()
        {
            while (true)
            {
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                Console.WriteLine("[아이템 목록]");
                // 아이템 목록 연결

                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나가기");

                string input = InputRemote();

                switch (input)
                {
                    case "0":
                        Console.Clear();
                        Scene_Main();
                        break;

                    default:
                        WrongInput();
                        continue;
                }
            }
        }

        // 상점 씬 //
        public void Scene_Shop()
        {
            
            while (true)
            {

                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                Console.WriteLine("[보유 골드]");
                Console.WriteLine(playerStatus.gold + "G\n");

                Console.WriteLine("[아이템 목록]");
                // 아이템 목록 연결
                system_Shop.ShopList();

                Console.WriteLine("");

                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("0. 나가기");

                string input = InputRemote();

                switch (input)
                {
                    case "0":
                        Console.Clear();
                        Scene_Main();
                        break;

                    case "1":
                        Console.Clear();
                        Scene_Shop_Buy();
                        continue;

                    default:
                        WrongInput();
                        continue;
                }
            }
        }

        public void Scene_Shop_Buy()
        {

            while (true)
            {

                Console.WriteLine("상점 - 아이템 구매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                Console.WriteLine("[보유 골드]");
                Console.WriteLine(playerStatus.gold + "G\n");

                Console.WriteLine("[아이템 목록]");
                system_Shop.BuyItems();     // 아이템 구매 목록

                Console.WriteLine("");

                Console.WriteLine("0. 나가기");

                string input = InputRemote();

                switch (input)
                {
                    case "0":
                        Console.Clear();
                        Scene_Shop();
                        break;

                    case "1":
                        Console.Write("아이템 구매");
                        continue;

                    default:
                        WrongInput();
                        continue;
                }

            
            }
        }
    }


    /* 캐릭터 스텟 클래스 */
    class PlayerStatus
    {
        public string name { get; set; } = "";
        public string job { get; set; } = "";
        public int lv { get; set; } = 01;
        public int atk { get; set; } = 10;
        public int def { get; set; } = 5;
        public int hp { get; set; } = 100;
        public int gold { get; set; } = 1500;
    }

    /* 아이템 효과로 상승하는 스텟 종류 */
    public enum Items_StatType
    {
        atk,
        def,
        hp
    }

    /* 아이템의 데이터 칼럼을 정의한 클래스 */
    public class Items_Data
    {
        // 아이템의 데이터 칼럼

        public int Id { get; set; }
        public string Name { get; set; }
        public Items_StatType StatType { get; set; }
        public int StatValue {  get; set; }
        public string Text { get; set; }
        public int Price { get; set; }
        public bool IsEquip { get; set; }
        public bool IsBuy{ get; set; }

        // 클래스의 생성자로 객체 생성 시 필드에 초기값 전달
        public Items_Data(int id, string name, Items_StatType statType, int statValue, string text, int price, bool isEquip, bool isBuy)
        {
            Id = id;
            Name = name;
            StatType = statType;
            StatValue = statValue;
            Text = text;
            Price = price;
            IsEquip = isEquip;
            IsBuy = isBuy;

        }   
    }
        
    /* 아이템 종류를 관리하는 클래스 */
    public class Items
    {
        //아이템 목록들을 관리하는 리스트 
        public List<Items_Data> ItemsList;

        public Items()
        {
            ItemsList = new List<Items_Data>();
            ItemsMake();
        }

        // 아이템을 생성 및 리스트에 추가
        private void ItemsMake()
        {
            // (번호, 이름, 스텟타입, 스텟 값, 설명, 가격, 장착여부, 소지여부)
            Items_Data noviceArmor = new Items_Data(1, "수련자 갑옷", Items_StatType.def, 5, "수련에 도움을 주는 갑옷입니다.", 1000, false, false);
            Items_Data ironArmor = new Items_Data(2, "무쇠 갑옷", Items_StatType.def, 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 9800, false, false);
            Items_Data SpartanArmor = new Items_Data(3, "스파르타의 갑옷", Items_StatType.def, 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 35000, false, false);
            Items_Data oldSword = new Items_Data(4, "낡은 검", Items_StatType.atk, 2, "쉽게 볼 수 있는 낡은 검 입니다.", 600, false, false);
            Items_Data bronzeAxe = new Items_Data(5, "청동 도끼", Items_StatType.atk, 5, "어디선가 사용됐던거 같은 도끼입니다.", 2200, false, false);
            Items_Data SpartanSpear = new Items_Data(6, "스파르타의 창", Items_StatType.atk, 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 3200, false, false);

            ItemsList.Add(noviceArmor);
            ItemsList.Add(ironArmor);
            ItemsList.Add(SpartanArmor);
            ItemsList.Add(oldSword);
            ItemsList.Add(bronzeAxe);
            ItemsList.Add(SpartanSpear);
        }

        // id를 통해 아이템을 가져오는 메서드
        //public Items_Data GetItemById(int id)
        //{
        //    return ItemsList.Find(item => item.Id == id);
        //}
    }


    class System_Inventory
    {
        void Equip()
        {

        }

        void MyInventory()
        {

        }
    }

    /* 상점 관리 시스템 */
    public class System_Shop
    {
        Items items = new Items();
        
        // 상품 목록
        public void ShopList()
        {
            foreach (var item in items.ItemsList)
            {
                Console.WriteLine($"- {item.Name}\t| {item.StatType} +{item.StatValue}\t| {item.Text}\t| {((item.IsBuy == true) ? "구매완료" : item.Price)} G");
            }
        }

        // 상품 구매 목록 (item.id 추가)
        public void BuyItems()
        {
            foreach (var item in items.ItemsList)
            {
                Console.WriteLine($"- {item.Id} {item.Name}\t| {item.StatType} +{item.StatValue}\t| {item.Text}\t| {((item.IsBuy == true) ? "구매완료" : item.Price)} G");
            }
        }

    }
}
