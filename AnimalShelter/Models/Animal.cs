using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using AnimalShelter;

namespace AnimalShelter.Models
{
    public class Animal
    {
      private string _name;
      private string _breed;
      private int _age;
      private DateTime _date;
      private string _gender;
      private string _type;

      public Animal(string animalName, string breed, int age, DateTime date, string gender, string type)
      {
        _name = animalName;
        _breed = breed;
        _age = age;
        _date = date;
        _gender = gender;
        _type = type;
      }

      public string GetName()
      {
        return _name;
      }

      public string GetBreed()
      {
        return _breed;
      }

      public int GetAge()
      {
        return _age;
      }

      public DateTime GetDate()
      {
        return _date;
      }

      public string GetGender()
      {
        return _gender;
      }

      public string GetAnimalType()
      {
        return _type;
      }

      public static List<Animal> GetAll()
      {
        List<Animal> allAnimals = new List<Animal> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM animal";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          string animalName = rdr.GetString(1);
          string breed = rdr.GetString(4);
          int age = rdr.GetInt32(5);
          DateTime date = rdr.GetDateTime(3);
          string gender = rdr.GetString(2);
          string animalType = rdr.GetString(6);
          Animal newAnimal = new Animal(animalName, breed, age, date, gender, animalType);
          allAnimals.Add(newAnimal);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allAnimals;
      }

      public static List<Animal> SortBy(string theType, string column)
      {
        List<Animal> allAnimals = new List<Animal> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM animal WHERE type='" + theType + "' ORDER BY " + column;
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          string animalName = rdr.GetString(1);
          string breed = rdr.GetString(4);
          int age = rdr.GetInt32(5);
          DateTime date = rdr.GetDateTime(3);
          string gender = rdr.GetString(2);
          string animalType = rdr.GetString(6);
          Animal newAnimal = new Animal(animalName, breed, age, date, gender, animalType);
          allAnimals.Add(newAnimal);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allAnimals;
      }

      public static void Save()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO `animal`(`ID`, `name`, `gender`, `date_admittance`, `breed`, `age`, `type`) VALUES (68, 'animalName', 'breed', 43, 'date', 'gender', 'type')";
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
      }

      public static void DeleteAll()
       {
           MySqlConnection conn = DB.Connection();
           conn.Open();

           var cmd = conn.CreateCommand() as MySqlCommand;
           cmd.CommandText = @"DELETE FROM animal;";

           cmd.ExecuteNonQuery();

           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
      }

    }
}
