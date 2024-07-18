namespace 박종요_과제_1._콘솔_프로젝트_제작
{
    internal class Program
    {
        enum Scene { Select, Confirm, Village, Inn, Park, Beach }
        enum Job { Warrior = 1, Mage, Archer, Rogue }
        enum Monster { Squirrel = 1, Oac, Jellyfish }//업데이트 예정...

        // 전사 = Warrior
        // 마법사 = Mage
        // 궁수 =  Archer
        // 도적 = Rogue
        struct GameData
        {
            public bool running;

            public Scene scene;
            public Monster monster;
            public string name;
            public Job job;
            public int curHP;
            public int maxHP;
            public int STR;
            public int INT;
            public int DEX;
            public int gold;
            public int EXP;
        }

        static GameData data;

        static void Main(string[] args)
        {
            Start();

            while (data.running)
            {
                Run();
            }

            End();
        }

        #region// 게임 시작

        static void Start()
        {
            data = new GameData();

            data.running = true;

            Console.WriteLine("===============================");
            Console.WriteLine("=                             =");
            Console.WriteLine("=        The first RPG        =");
            Console.WriteLine("=                             =");
            Console.WriteLine("===============================");
            Console.WriteLine();
            Console.WriteLine("계속하려면 아무키나 눌러주세요");
            Console.ReadKey();
        }
        #endregion

        #region// 게임 종료
        static void End()
        {
            Console.Clear();
            Console.WriteLine("=============================");
            Console.WriteLine("=                           =");
            Console.WriteLine("=         Game Over         =");
            Console.WriteLine("=                           =");
            Console.WriteLine("=============================");
        }
        #endregion

        #region//Run
        static void Run()
        {
            Console.Clear();

            switch (data.scene)
            {
                case Scene.Select:
                    SelectScene();
                    break;
                case Scene.Confirm:
                    ConfirmScene();
                    break;
                case Scene.Village:
                    VillageScene();
                    break;
                case Scene.Inn:
                    InnScene();
                    break;
                case Scene.Park:
                    ParkScene();
                    break;
                case Scene.Beach:
                    BeachScene();
                    break;
                default:
                    break;

            }
            #endregion

        #region // 선택하기

            static void SelectScene()
            {
                Console.WriteLine("이름을 입력하세요");
                data.name = Console.ReadLine();
                if (data.name == "")
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다. 다시 입력하세요.");
                    Wait(2);
                    return;
                }

                Wait(0.2f);
                Console.WriteLine();
                Console.WriteLine("직업을 선택하세요.");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 마법사");
                Console.WriteLine("3. 궁수");
                Console.WriteLine("4. 도적");
                Console.Write("선택 : ");


                if (int.TryParse(Console.ReadLine(), out int select) == false)
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Wait(2);
                    return;
                }
                else if (Enum.IsDefined(typeof(Job), select) == false)
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Wait(2);
                    return;
                }

                switch ((Job)select)
                {
                    case Job.Warrior:
                        data.job = Job.Warrior;
                        data.maxHP = 200;
                        data.curHP = data.maxHP;
                        data.STR = 20;
                        data.INT = 5;
                        data.DEX = 10;
                        data.gold = 100;
                        data.EXP = 0;
                        break;
                    case Job.Mage:
                        data.job = Job.Mage;
                        data.maxHP = 120;
                        data.curHP = data.maxHP;
                        data.STR = 5;
                        data.INT = 30;
                        data.DEX = 8;
                        data.gold = 300;
                        data.EXP = 0;
                        break;
                    case Job.Archer:
                        data.job = Job.Archer;
                        data.maxHP = 150;
                        data.curHP = data.maxHP;
                        data.STR = 12;
                        data.INT = 8;
                        data.DEX = 15;
                        data.gold = 50;
                        data.EXP = 0;
                        break;
                    case Job.Rogue:
                        data.job = Job.Rogue;
                        data.maxHP = 100;
                        data.curHP = data.maxHP;
                        data.STR = 15;
                        data.INT = 10;
                        data.DEX = 20;
                        data.gold = 0;
                        data.EXP = 0;
                        break;
                }
                data.scene = Scene.Confirm;
            }
            #endregion

        #region//캐릭터 정보
            static void PrintProfile()
            {
                Console.WriteLine("=====================================");
                Console.WriteLine($"이름 : {data.name,-6} 직업 : {data.job,-6}");
                Console.WriteLine($"체력 : {data.curHP,+3} / {data.maxHP}");
                Console.WriteLine($"힘 : {data.STR,-3} 지력 : {data.INT,-3} 민첩 : {data.DEX,-3}");
                Console.WriteLine($"소지금 : {data.gold,+5} G");
                Console.WriteLine($"경험치 : {data.EXP,+5}");
                Console.WriteLine("=====================================");
                Console.WriteLine();
                
            }
            #endregion

        #region//초기 캐릭터 설정
            static void ConfirmScene()
            {
                Console.WriteLine("==================================");
                Console.WriteLine($"이름   :  {data.name}");
                Console.WriteLine($"직업   :  {data.job}");
                Console.WriteLine($"체력   :  {data.maxHP}");
                Console.WriteLine($"힘     :  {data.STR}");
                Console.WriteLine($"지력   :  {data.INT}");
                Console.WriteLine($"민첩   :  {data.DEX}");
                Console.WriteLine($"소지금 :  {data.gold}");
                Console.WriteLine($"경험치 :  {data.EXP}");
                Console.WriteLine("==================================");
                Console.WriteLine();
                Console.WriteLine("이대로 플레이 하시겠습니까? (y/n)");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "Y":
                    case "y":
                        Console.Clear();
                        Console.WriteLine("마을로 이동합니다....");
                        Wait(2);
                        data.scene = Scene.Village;
                        break;
                    case "N":
                    case "n":
                        data.scene = Scene.Select;
                        break;
                    default:
                        data.scene = Scene.Select;
                        break;
                }

            }
            #endregion

        #region// 진행 결과
            static void Result(string why)
            {
                if (data.curHP <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("플레이어가 사망하였습니다...");
                    Wait(3);
                    data.running = false;
                }
                else
                {
                    Wait(2);
                    Console.WriteLine($"{why}");
                    Console.WriteLine() ;
                    Console.WriteLine("마을로 돌아갑니다...");
                    Wait(2);
                    data.scene = Scene.Village;
                }
            }
            
            #endregion

        #region // 사냥 보상
            static void Reward(int gold, int EXP)
            {
               data.gold += 50;
               Console.WriteLine($"{gold}G를 획득합니다.");
               Wait(1);
               data.EXP += 100;
               Console.WriteLine($"{100} 경험치를 획득합니다.");
               Wait(1);
                
            }
            #endregion

        #region//시간기능
        static void Wait(float seconds)
        {
            Thread.Sleep((int)(seconds * 1000));
        }
        #endregion

        #region//장면1. 마을
            static void VillageScene()
            {
                PrintProfile();
                Console.WriteLine("평화로운 마을입니다.");
                Console.WriteLine("어디로 이동하시겠습니까?");
                Console.WriteLine();
                Console.WriteLine("1. 여관");
                Console.WriteLine("2. 상점");
                Console.WriteLine("3. 공원");
                Console.WriteLine("4. 해수욕장");

                string place = Console.ReadLine();

                switch (place)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("여관으로 이동합니다...");
                        Wait(2);
                        data.scene = Scene.Inn;
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("상점으로 이동합니다...");
                        Console.WriteLine("추후 업데이트 예정");
                        Wait(2);
                        data.scene = Scene.Village;
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("공원으로 이동합니다...");
                        Wait(2);
                        data.scene = Scene.Park;
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("해수욕장으로 이동합니다...");
                        Wait(2);
                        data.scene = Scene.Beach;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("유효하지 않은 입력입니다. 다시 입력해주세요.");
                        Wait(1);
                        return;
                }
            }
            #endregion

        #region//장면2. 여관
            static void InnScene()
            {
                Console.WriteLine($"안녕하세요. {data.name}님!");
                Wait(2);
                Console.WriteLine("휴식을 취하시겠습니까? (y/n)");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "Y":
                    case "y":
                        {
                            Console.WriteLine("숙박료로 50G를 지불합니다.");
                            data.gold -= 50;
                            Wait(3);

                            if (data.curHP >= data.maxHP)
                            { 
                                Console.Clear();
                                Console.WriteLine($"현재 {data.name}님은 휴식이 필요없는 상태입니다.");
                                Wait(2);
                                Console.WriteLine("숙박료로 받은 50G를 되돌려받았습니다.");
                                data.gold += 50;
                                Wait(2);
                                Console.WriteLine("마을로 돌아갑니다...");
                                Wait(2);
                                data.scene = Scene.Village;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("..zzz..");
                                Wait(2);
                                Console.WriteLine("....zzz...");
                                Wait(3);
                                Console.Clear();
                                Console.WriteLine($"{data.name}의 체력을 모두 회복되었습니다!");
                                data.curHP = data.maxHP;
                                Wait(2);
                                Console.WriteLine();
                                Console.WriteLine("마을로 돌아갑니다...");
                                Wait(2);
                                data.scene = Scene.Village;
                            }
                            break;
                        }
                    case "N":
                    case "n":
                        {
                            Console.WriteLine("마을로 돌아갑니다...");
                            Wait(2);
                            data.scene = Scene.Village;
                        }
                        break;

                    default:
                        return;
                }
            }
            #endregion

        #region//장면3. 숲
            static void ParkScene()
            {
                Console.WriteLine("포근하고 따뜻한 아침의 공원입니다.");
                Wait(1);
                Console.WriteLine("저 멀리 귀여운 다람쥐가 있습니다.");
                Wait(1);
                Console.WriteLine("어떤 행동을 하시겠습니까?");
                Console.WriteLine("1. 다람쥐를 때린다 (힘)");
                Console.WriteLine("2. 다람쥐를 공격마법을 시전한다 (지력)");
                Console.WriteLine("3. 다람쥐를 향해 돌맹이를 던진다 (민첩)");
                string action = Console.ReadLine();
                Console.Clear();
                switch (action)
                {
                    case "1":
                        if (data.STR > 10)
                        {
                            Console.WriteLine("때리기 효과는 굉장했습니다!");
                            Wait(1);
                            Console.WriteLine("다람쥐가 쓰러졌습니다.");
                            Wait(1);
                            Reward(50, 100);
                        }
                        else
                        {
                            Console.WriteLine("다람쥐에게 아무런 효과가 없습니다");
                            Wait(1);
                            Console.WriteLine("화가난 다람쥐가 공격합니다");
                            Wait(2);
                            Console.WriteLine("체력이 20 감소합니다.");
                            data.curHP -= 20;
                            Wait(3);
                        }
                        break;
                    case "2":
                        if (data.INT > 10)
                        {
                            Console.WriteLine("공격마법의 효과는 굉장했습니다!");
                            Wait(1);
                            Console.WriteLine("다람쥐가 쓰러졌습니다.");
                            Wait(1);
                            Reward(50, 100);

                        }
                        else
                        {
                            Console.WriteLine("다람쥐에게 아무런 효과가 없습니다");
                            Wait(1);
                            Console.WriteLine("화가난 다람쥐가 공격합니다");
                            Wait(2);
                            Console.WriteLine("체력이 20 감소합니다.");
                            data.curHP -= 20;
                            Wait(3);
                        }
                        break;
                    case "3":
                        if (data.DEX > 10)
                        {
                            Console.WriteLine("투척 효과는 굉장했습니다!");
                            Wait(1);
                            Console.WriteLine("다람쥐가 쓰러졌습니다.");
                            Wait(1);
                            Reward(50, 100);
                        }
                        else
                        {
                            Console.WriteLine("다람쥐에게 아무런 효과가 없습니다");
                            Wait(1);
                            Console.WriteLine("화가난 다람쥐가 공격합니다");
                            Wait(2);
                            Console.WriteLine("체력이 20 감소합니다.");
                            data.curHP -= 20;
                            Wait(3);
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("...");
                Console.WriteLine("......");
                Result("공원에서 할 일이 없습니다.");
                
            }
            #endregion  

        #region//장면4. 해수욕장
            static void BeachScene()
            {
                Console.WriteLine("마을 옆 한적한 해수욕장입니다.");
                Console.WriteLine("수영을 하시겠습니까? (y/n)");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "Y":
                    case "y":
                        {
                            Console.Clear();
                            Wait(1);
                            Console.WriteLine("수영중인 플레이어 앞에 해파리가 나타났습니다.");
                            Wait(2);
                            Console.WriteLine("해파리가 플레이어에게 독을 쏘았습니다.");

                            if (data.STR < 15)
                            {
                                Wait(2);
                                Console.WriteLine("체력이 50 감소합니다. (힘이 15이상이면 독 면역)");
                                data.curHP -= 50;
                                Wait(3);
                                Console.WriteLine();
                                Console.WriteLine("독으로 인하여 몸에 힘이 빠졌습니다...");
                                Result("독에 감염된 플레이어가 쉬고 싶어합니다.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine();
                                Wait(3);
                                Console.WriteLine("높은 힘으로 인하여 독에 면역되었습니다!");
                                Wait(4);
                            }

                            Console.Clear();
                            Wait(2);
                            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                            Wait(3);
                            Console.Clear();
                            Console.WriteLine("바다 깊은 곳에서 신비한 상자를 발견했습니다!");
                            if (data.DEX < 15)
                            {
                                Console.WriteLine();
                                Wait(2);
                                Console.WriteLine("...");
                                Wait(4);
                                Console.WriteLine("이런! 수영능력이 부족합니다. (DEX 15이상 필요)");
                                Wait(2);
                                Console.WriteLine("아쉽지만 신비한 상자를 포기합니다...");
                            }
                            else
                            {
                                Wait(2);
                                Console.WriteLine("현란한 수영실력으로 잠수하여 상자를 오픈합니다.");
                                Wait(2);
                                Console.WriteLine("축하합니다! 상자에서 500G를 획득하였습니다.");
                                data.gold += 500;
                            }

                        }
                        
                        Console.WriteLine();
                        Wait(3);
                        Console.WriteLine("마을로 돌아갑니다...");
                        Wait(2);
                        data.scene = Scene.Village;
                        break;

                    case "N":
                    case "n":
                        {
                            Console.WriteLine("마을로 돌아갑니다...");
                            Wait(2);
                            data.scene = Scene.Village;
                        }
                        break;

                    default:
                        return;
                }

            }
            #endregion
        }
    }
}
