using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using AnimalShelter;

namespace AnimalShelter.Models
{
    public class Cat
    {
      private string _name;
      private string _breed;
      private int _age;
      private DateTime _date;
      private string _gender;

      public Cat(string animalName, string breed, int age, DateTime date, string gender)
      {
        _name = animalName;
        _breed = breed;
        _age = age;
        _date = date;
         _gender = gender;
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

      public static List<Cat> GetAll()
      {
        List<Cat> allCats = new List<Cat> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM cat";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          string animalName = rdr.GetString(1);
          string breed = rdr.GetString(4);
          int age = rdr.GetInt32(5);
          DateTime date = rdr.GetDateTime(3);
          string gender = rdr.GetString(2);
          Cat newCat = new Cat(animalName, breed, age, date, gender);
          allCats.Add(newCat);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allCats;
      }

      public static List<Cat> SortBy(string column)
      {
        List<Cat> allCats = new List<Cat> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM cat ORDER BY " + column;
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          string animalName = rdr.GetString(1);
          string breed = rdr.GetString(4);
          int age = rdr.GetInt32(5);
          DateTime date = rdr.GetDateTime(3);
          string gender = rdr.GetString(2);
          Cat newCat = new Cat(animalName, breed, age, date, gender);
          allCats.Add(newCat);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allCats;
      }

    }
}
