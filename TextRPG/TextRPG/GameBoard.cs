using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace TextRPG
{
    internal class GameBoard
    {
        static void Main(string[] args) 
        {
            Scenes scenes = new Scenes();       // Scenes 클래스 인스턴스화


            scenes.MakeCharacterScene();     // 캐릭터 생성 씬 실행
               
            Console.Clear();

            scenes.MainScene();         // 게임 시작 씬 실행
            
        }
        

    }
    
    public class Scenes     // 장면을 관리하는 클래스
    {
        private PlayerStatus playerStatus;      // 스텟 클래스 필드 선언


        public int InputRemote()       // 중복되는 인풋 코드를 메서드화
        {
            Console.Write("\n>> ");
            return int.Parse(Console.ReadLine());
        }


        public void MakeCharacterScene()     // 캐릭터 생성 씬
        {
            playerStatus = new PlayerStatus();

            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.Write("원하시는 이름을 설정해주세요. \n\n>> ");
            playerStatus.name = Console.ReadLine();     // 이름 결정
            Console.WriteLine($"\n입력하신 이름은 {playerStatus.name} 입니다.\n");

            while (true)        // 올바른 값 입력할 때 까지 무한 루프
            {
                Console.WriteLine("원하시는 직업을 설정해주세요.");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 도적");

                int input = InputRemote();

                switch (input)       // 직업 결정
                {
                    case 1:
                        playerStatus.job = "전사";
                        break;

                    case 2:
                        playerStatus.job = "도적";
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("<<올바른 값을 입력해주세요.>>\n");
                        continue;
                }
                break;
            }
        }

        public void MainScene()     // 게임 시작(메인 화면) 씬
        {
            while (true)
            {
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");

                int input = InputRemote();

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        StatusScene();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("<<올바른 값을 입력해주세요.>>\n");
                        continue;
                }
            }

        }

        public void StatusScene( )      // 상태 보기 씬
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

                int input = InputRemote();

                switch (input)
                {
                    case 0:
                        Console.Clear();
                        MainScene();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("<<올바른 값을 입력해주세요.>>\n");
                        continue;
                }
            }

        }

        public void InventoryScene()
        {
            while (true)
            {
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                Console.WriteLine("[아이템 목록]");

                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나가기");

                int input = InputRemote();

                switch (input)
                {
                    case 0:
                        Console.Clear();
                        MainScene();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("<<올바른 값을 입력해주세요.>>\n");
                        continue;
                }
            }

    }
    class PlayerStatus       // 캐릭터 스텟
    {
        public string name;
        public string job;
        public int lv = 01;
        public int atk = 10;
        public int def = 5;
        public int hp = 100;
        public int gold = 1500;

        
    }
}
