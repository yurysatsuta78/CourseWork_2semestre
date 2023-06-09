﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kurs
{
    static class List
    {
        public static AddCarForm adcf = new AddCarForm();
        public static ShowCarsForm scaf = new ShowCarsForm();
        public static Basket bask = new Basket();
        public static Addmoneyform adm = new Addmoneyform();
        #region списки
        static public List<Car> carList = new List<Car>();
        static public List<Car> basket = new List<Car>();
        static public List<string> models = new List<string>();
        static public double allprice;
        public static List<Car> favouritesList = new List<Car>();
        public static List<int> basketidList = new List<int>();
        #endregion

        #region списки с моделями
        public static List<string> mazdacarModels = new List<string> { "121", "323", "626", "RX-8", "RX-7" };
        public static List<string> nissancarModels = new List<string> { "Skyline", "Silvia", "GT-R", "Juke" };
        public static List<string> toyotacarModels = new List<string> { "Corolla", "Cresta", "Mark 2", "Chaser" };
        public static List<string> audicarModels = new List<string> { "100", "200", "Coupe", "A6" };
        public static List<string> ladacarModels = new List<string> { "2107", "2114", "2121", "Priora" };
        public static List<string> mitsubishicarModels = new List<string> { "3000GT", "Pajero", "Lancer", "Lancer Evolution", "Eclipse" };
        public static List<string> citroencarModels = new List<string> { "XM", "Xsara", "C6", "CX" };
        public static List<string> opelcarModels = new List<string> { "Vectra", "Omega", "Astra", "Calibra" };
        public static List<string> bmwcarModels = new List<string> { "M2", "M3", "M4" };
        public static List<string> subarucarModels = new List<string> { "Forester", "Impreza", "Impreza WRX STI", "BRZ" };
        public static List<string> volkswagencarModels = new List<string> { "Passat", "Polo", "Golf", "Golf R" };
        #endregion

        #region методы
        public static void AddCar(Car ccar) 
        {
            carList.Add(ccar);
        }
        public static void AddBasket(Car ccar) 
        {
            basket.Add(ccar);
        }
        public static void Reload()
        {
            Database DB = new Database();
            string strCars = String.Format("Select * From Car Where Sold = {0}", 0);
            SqlCommand cmdCars = new SqlCommand(strCars, DB.getConnection());
            DB.openConnection();
            SqlDataReader CarsDataReader = cmdCars.ExecuteReader();
            List.carList.Clear();
            while (CarsDataReader.Read())
            {
                int carid = CarsDataReader.GetInt32(0);
                string brand = CarsDataReader.GetString(1);
                string model = CarsDataReader.GetString(2);
                int year = CarsDataReader.GetInt32(3);
                double price = CarsDataReader.GetDouble(4);
                string enginevolume = CarsDataReader.GetString(5);
                string enginetype = CarsDataReader.GetString(6);
                string comment = CarsDataReader.GetString(7);
                string phonenumber = CarsDataReader.GetString(8);
                string driveunit = CarsDataReader.GetString(9);
                string transmission = CarsDataReader.GetString(10);
                int sold = CarsDataReader.GetInt32(11);
                Car car = new Car(carid, brand, model, year, price, enginevolume, enginetype, driveunit, comment, phonenumber, transmission, sold);
                List.AddCar(car);
            }
            DB.closeConnection();
        }
        public static void BasketReload()
        {
            Database DB = new Database();
            try
            {
                string strFav = "Select CarId From Basket Where UserId = @userid";
                SqlCommand cmd = new SqlCommand(strFav, DB.getConnection());
                cmd.Parameters.AddWithValue("@userid", User.userid);
                DB.openConnection();
                SqlDataReader baskreader = cmd.ExecuteReader();
                List.basketidList.Clear();
                while (baskreader.Read())
                {
                    int carid = baskreader.GetInt32(0);
                    List.basketidList.Add(carid);
                }
            }
            catch
            {
                MessageBox.Show("Не удалось загрузить Id корзины!");
            }
            finally
            {
                DB.closeConnection();
            }
            List.basket.Clear();
            foreach (int item in List.basketidList)
            {
                foreach (Car car in List.carList)
                {
                    if (car.Carid == item)
                    {
                        List.basket.Add(car);
                    }
                }
            }
        }
        #endregion
    }
}
