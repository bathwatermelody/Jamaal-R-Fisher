using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DL
{
    public class FileRepo : IRepo
    {

        readonly string connectionSQL;
        public FileRepo(string connectionSQL)
        {
            this.connectionSQL = connectionSQL;
        }

        public Restaurant AddRestaurant(Restaurant reviewToAdd)
        {
            string selectSQL = $"UPDATE x SET Review = Review + @rating,TotalRatings = TotalRatings + 1 WHERE Id = '{Id}'";
            using SqlConnection localConnection = new(connectionSQL);
            using SqlCommand command1 = new(selectSQL, localConnection);
            command1.Parameters.AddWithValue("@rating", reviewToAdd);
            localConnection.Open();
            command1.ExecuteNonQuery();
            using SqlDataReader reader = command1.ExecuteReader();
            /*
            string selectSQL = $"UPDATE x SET Review = Review + @rating,TotalRatings = TotalRatings + 1 WHERE Id = '{Id}'";
            using SqlConnection localConnection2 = new(connectionSQL);
            using SqlCommand command2 = new(selectSQL, localConnection2);
            command2.Parameters.AddWithValue("@rate", reviewToAdd);
            localConnection.Open();
            command2.ExecuteNonQuery();
            using SqlDataReader reader = command2.ExecuteReader();
            */
        }


        public List<x> GetAllRestaurants()
        {
            string selectCommandString = "SELECT * FROM x";

            using SqlConnection connection = new(connectionSQL);
            using SqlCommand command = new(selectCommandString, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            var Restaurants = new List<x>();
            while (reader.Read())
            {
                Restaurants.Add(new x
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1),
                    Zipcode = reader.GetString(2),
                    Rating = reader.GetDouble(3),
                    Review = reader.GetString(4),
                    TotalRatings = reader.GetInt32(5)
                });
            }
            return Restaurants;

            List<Restaurant> SearchRestaurants(string searchTerm)
            {
                throw new NotImplementedException();
            }

            bool IsDuplicate(Restaurant restaurant)
            {
                throw new NotImplementedException();
            }

            void AddReview(int restaurantId, Review reviewToAdd)
            {
                throw new NotImplementedException();
            }

            List<Review> GetAllReviews()
            {
                throw new NotImplementedException();
            }

            /*
            private string filePath = "../DL/Database/";
            string? jsonString;

            public Restaurant AddRestaurant(Restaurant restaurantToAdd)
            {
                List<Restaurant>? restaurants = GetAllRestaurants();
                restaurants.Add(restaurantToAdd);
                string? restaurantString = JsonSerializer.Serialize<List<Restaurant>>(restaurants, new JsonSerializerOptions { WriteIndented = true });
                try
                {
                    File.WriteAllText(filePath + "Restaurant.json", restaurantString);
                }
                catch (DirectoryNotFoundException ex)
                {
                    Console.WriteLine("Please check the path, " + ex.Message);
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("Please check the file name, " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return restaurantToAdd;
            }
            public List<Restaurant> GetAllRestaurants()
            {
                try
                {
                    jsonString = File.ReadAllText(filePath + "Restaurant.json");
                }
                catch (DirectoryNotFoundException ex)
                {
                    Console.WriteLine("Please check the path, " + ex.Message);
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("Please check the file name, " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (!string.IsNullOrEmpty(jsonString))
                    return JsonSerializer.Deserialize<List<Restaurant>>(jsonString)!;
                throw new InvalidDataException("json data missing or invalid");
            }

            private string filePath3 = "../DL/Database/";
            string? jsonString3;
            public User AddNewUser(User userToAdd)
            {
                List<User>? users = GetAllUsers();
                users.Add(userToAdd);
                string? userString = JsonSerializer.Serialize<List<User>>(users, new JsonSerializerOptions { WriteIndented = true });
                try
                {
                    File.WriteAllText(filePath + "User.json", userString);
                }
                catch (DirectoryNotFoundException ex)
                {
                    Console.WriteLine("Please check the path, " + ex.Message);
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("Please check the file name, " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return userToAdd;
            }

            public void GetAllUsers()
            {
                jsonString3 = File.ReadAllText(filePath3 + "User.json");
                Console.WriteLine(jsonString3);
            }

            private string filePath2 = "../DL/Database/";
            string? jsonString2;
            public Review AddReview(Review rating)
            {
                throw new System.NotImplementedException();
            }

            public void GetAllReviews()
            {
                jsonString2 = File.ReadAllText(filePath2 + "Review.json");
                Console.WriteLine(jsonString2);
            }

            public void AddReview(int restaurantId, Review reviewToAdd)
            {
                throw new NotImplementedException();
            }

            List<Review> IRepo.GetAllReviews()
            {
                throw new NotImplementedException();
            }
            */
        }
    }
}