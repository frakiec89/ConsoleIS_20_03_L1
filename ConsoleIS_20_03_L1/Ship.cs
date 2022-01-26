using System;

namespace ConsoleIS_20_03_L1
{
    public class Ship
    {
        /// <summary>
        /// имя корабля
        /// </summary>
        public  string Name { get; private set; }
        /// <summary>
        /// Скорость корабля в условных единицах
        /// </summary> 
        public  int Speed {  get; private set; }
        /// <summary>
        /// уровень жизни
        /// </summary>
        public int HitPoint { get; set; }
        /// <summary>
        /// сила атаки
        /// </summary>
        public int  ValueAtk { get; set; }

        int _x_track;

        /// <summary>
        /// точка в  пространстве 
        /// </summary>
        public  int  X_Track {
            
            get
            {

                if (_x_track > 1000)
                    return 1000;

                if (_x_track < -1000)
                    return -100;

                return _x_track;
            }
            
            private set
            {
                _x_track = value;
            }
        
        }

        public Ship(string name, int speed, int hitPoint, int valueAtk)
        {
            Name = name;
            Speed = speed;
            HitPoint = hitPoint;
            ValueAtk = valueAtk;
            X_Track = 0; // все корабли  стартуют с верфи  точка 0
        }

        /// <summary>
        /// Метод  перемещения  корабля
        /// </summary>
        /// <param name="time">в минутах</param>
        /// <param name="vector">true - вперед , false - назад</param>
        /// <returns>Сообщение о перемещении корабля</returns>
        public string Moving (int  time , bool vector)
        { 
            if (IsDrown() == false)
            {
                return $"Корабль {Name} потонул";
            }


            if (time<0) //проверка на корректность времени
            {
                return "Неконкретное  время";
            }

            if(vector)
            {
                X_Track += time * Speed; // движение вперед 
            }
            else
            {
                X_Track -= time * Speed; // движение назад 
            }
            return $"Корабль {Name}  переместился в  точку {X_Track} ";
        }

        public string Info()
        {
            if (IsDrown() == false)
            {
                return $"Корабль {Name} потонул";
            }

            return $"Корабль {Name} находиться в точке {X_Track}" +
                $" У него осталось  {HitPoint} hp";
        }

        /// <summary>
        /// проверяет  хп  у  коробя
        /// </summary>
        /// <returns> да  если живой </returns>
       public bool IsDrown()
        {
            if (HitPoint > 0) return true;
            else return false;
        }

        public  string Atack  ( Ship ship)
        {
            if (  Math.Abs (ship.X_Track - X_Track ) >2)
            {
                return $"Корабли {Name} {ship.Name} " +
                    $"не могут  вступить в бой";
            }

            if (!ship.IsDrown() || !IsDrown()  )
            {
                return $"Корабли {Name} {ship.Name} " +
                   $"не могут  вступить в бой";
            }

            #region Атака
            double countAtakMy = ship.HitPoint / ValueAtk;
            double countAtakCopernicus = HitPoint / ship.ValueAtk;

            if (countAtakCopernicus == countAtakMy)
            {
                ship.HitPoint = 0 ;
                HitPoint = ship.ValueAtk;
                return $"Корабль {Name} победил \n" +
                    Info();
            }

            if (countAtakMy< countAtakCopernicus)
            {
                ship.HitPoint = 0;
                HitPoint -= (int)countAtakMy * ship.ValueAtk;
                return $"Корабль {Name} победил \n" +
                    Info();
            }
            else
            {
                HitPoint = 0;

                ship.HitPoint -= (int)countAtakCopernicus * ValueAtk;

                return $"Корабль {ship.Name} победил \n" +
                   ship.Info();
            }
            #endregion
        }
    }
}
