namespace TextRPG
{
    public class PlayerStatus       // 캐릭터 스텟
    {
        public string name = "";
        public string job = "";
        public int atk = 10;
        public int def = 5;
        public int hp = 100;
        public int gold = 1500;
    }

    internal class GameBoard
    {
        static void Main(string[] args) 
        {
            bool isMakeCharacter = false;
            int sceneNumber = 0;

            if (isMakeCharacter == false)
            {
                MakeCharacter();
                isMakeCharacter = true;
                Console.Clear();
            }

            while (true)
            {
                switch (sceneNumber)
                {
                    case 0:
                        MainScene();
                        break;
                    

                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }

                Console.Write("\n>> ");
                sceneNumber = int.Parse(Console.ReadLine());

            }

            
            
        }

        static void MakeCharacter()
        {
            PlayerStatus playerStatus = new PlayerStatus();

            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.Write("원하시는 이름을 설정해주세요. \n\n>> ");
            playerStatus.name = Console.ReadLine();
            Console.Write($"\n입력하신 이름은 {playerStatus.name} 입니다.");


            while (true)        // 올바른 값 입력할 때 까지 무한 루프
            {
                Console.WriteLine("\n원하시는 직업을 설정해주세요.");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 도적");

                Console.Write("\n>> ");

                int jobInput = int.Parse(Console.ReadLine());

                switch (jobInput)
                {
                    case 1:
                        playerStatus.job = "전사";
                        break;

                    case 2:
                        playerStatus.job = "도적";
                        break;

                    default:
                        Console.WriteLine("올바른 값을 입력해주세요.");
                        continue;
                }
                break;
            }
        }

        static void MainScene()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            
        }
    
    }
}
