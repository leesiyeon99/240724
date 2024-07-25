namespace Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory<Potion> potionInventory = new(10); //인벤토리 사이즈를 10으로 설정해줌

            potionInventory.Add(new Potion("체력 포션"));
            potionInventory.Add(new Potion("마나 포션"));
            potionInventory.Add(new Potion("경험치 포션"));
            potionInventory.Add(new Potion("활력 포션")); //각각 인덱스에 포션을 추가해줌

            potionInventory.Remove();
            potionInventory.Remove(); // 인덱스 3번째 활력포션과 2번의 경험치 포션이 지워짐

            potionInventory.PrintItemNames(); //목록프린트시 체력포션과 마나포션이 목록에 존재하게 됨
        }
    }

    public abstract class Item //추상클래스를 사용해 자식클래스가 구체화시켜 표현할 것을 염두에 둠
    {
        public string Name { get; private set; } 

        public Item(string name) // 아이템 이름의 생성자를 만듦
        {
            Name = name;
        }
    }

    public class Potion : Item // 아이템 상속받음
    {
        public Potion(string name) : base(name) { } // 포션의 이름을 인자값으로 받아오기 위해 base사용
    }

    public class Inventory<T> where T : Item // 아이템을 담을 인벤토리 클래스를 생성해주고 인벤토리에서 받을 자료형은 Item 클래스로 제약을 걸어둠
    {
        //아이템 목록과, 아이템 번호를 만들어주고 인벤토리 내에서만 사용할 수 있게 접근제한자 적용
        private T[] _list;
        private int _index;

        public Inventory(int size) //인벤토리 크기의 생성자를 만들어 목록의 크기를 정함
        {
            _list = new T[size];
        }

        public void Add(T item) // 인벤토리에 아이템을 추가하는 함수를 만드는데 추가할 수 있는 것은 위에서 일반화시킨 Item클래스의 item을 받아옴
        {
            if (_index < _list.Length) // 목록의 길이보다 아이템번호가 작다면 번호에 아이템을 추가해주고 인덱스 번호를 증가시켜 다음 아이템을 받을 수 있게 설정해줌
            {
                _list[_index] = item;
                _index++;
            }
        }

        public void Remove() //인벤토리에 아이템을 없애는 함수를 만들어주는데 아이템 번호가 0보다 클 때 사용할 수 있으며 배열은 -1을 해줘야 번호에 맞는 아이템을 지울 수 있기 때문에 인덱스를 빼주고 null을 집어넣음
        {
            if(_index > 0) 
            { 
            _index--;
            _list[_index] = null;
            }
        }

        public void PrintItemNames() //들어있는 아이템목록을 프린트 하는 함수를 만들어줌
        {
            Console.WriteLine("아이템 목록: ");

            foreach (var item in _list)//foreach를 사용하여 목록의 아이템이 존재한다면 출력해줌
            {
                if (item != null)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }

    }


}
