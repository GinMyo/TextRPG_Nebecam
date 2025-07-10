namespace TextRPG
{
    public enum Scenes      //게임 씬 종류
    {
        MainScene = 1,
        StatusScene,
        InventoryScene,
        ShopScene
    }


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
            

            if (isMakeCharacter == false)
            {
                MakeCharacter();
            }
            
            Console.WriteLine();
        }

        static void MakeCharacter()
        {
            PlayerStatus playerStatus = new PlayerStatus();
            string name = playerStatus.name;
            string job = playerStatus.job;

            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.Write("원하시는 이름을 설정해주세요. \n\n>> ");
            name = Console.ReadLine();
            Console.Write($"\n입력하신 이름은 {name} 입니다.");


            while (true)        // 올바른 값 입력할 때 까지 무한 루프
            {
                Console.WriteLine("\n원하시는 직업을 설정해주세요.");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 도적");
                Console.Write("\n\n>> ");

                job = Console.ReadLine();

                switch (job)
                {
                    case "1":
                        Console.WriteLine("전사를 선택하셨습니다. ");
                        break;

                    case "2":
                        Console.WriteLine("도적을 선택하셨습니다. ");
                        break;

                    default:
                        Console.WriteLine("올바른 값을 입력해주세요. ");
                        continue;
                }

                break;
            }


        }
    
    }
}
