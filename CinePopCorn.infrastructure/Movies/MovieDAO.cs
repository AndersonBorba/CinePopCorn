using CinePopCorn.Domain.Movies;
using CinePopCorn.infrastructure.AuxDao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinePopCorn.infrastructure.Movies
{
    public class MovieDAO
    {
        public List<Movie> GetMovies()
        {
            SqlConnection connection = new SqlConnection(AuxDAO.GetConnectionString());
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"select Id, Title, Description, Time from Movie";
            SqlDataReader rdr = cmd.ExecuteReader();
            List<Movie> movies = new List<Movie>();
            while (rdr.Read())
            {
                Movie movie = new Movie();
                movie.Id = Convert.ToInt32(rdr["Id"]);
                movie.Title = Convert.ToString(rdr["Title"]);
                movie.Description = Convert.ToString(rdr["Description"]);
                movie.Time = Convert.ToInt32(rdr["Time"]);
                movies.Add(movie);
            }
            connection.Close();

            return movies;
        }

        public int GetSessionByIdMovie(int id)
        {
            SqlConnection connection = new SqlConnection(AuxDAO.GetConnectionString());
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"select count(1) from Session where IdMovie = @Id;";
            cmd.Parameters.AddWithValue("@Id", id);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            return result;
        }

        public Movie GetMovieByTitle(string title)
        {
            Movie m = new Movie();
            SqlConnection connection = new SqlConnection(AuxDAO.GetConnectionString());
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"select Id, Title, Description, Time from Movie where title = @Title";
            cmd.Parameters.AddWithValue("@Title", title);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                m.Id = Convert.ToInt32(rdr["Id"]);
                m.Title = Convert.ToString(rdr["Title"]);
                m.Time = Convert.ToInt32(rdr["Time"]);
            }
            connection.Close();
            return m;
        }

        public int GetRepeatedTitles(string title, int id)
        {
            SqlConnection connection = new SqlConnection(AuxDAO.GetConnectionString());
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"select count(1) from Movie where title = @Title ";
            if (id > 0)
                cmd.CommandText += @" AND Id <> @Id;";
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Id", id);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();

            return result;
        }

        public string UpdateMovie(Movie m)
        {
            try
            {
                SqlConnection connection = new SqlConnection(AuxDAO.GetConnectionString());
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                if (m.Image != null)
                    cmd.CommandText = @"UPDATE Movie set Image = @Image, Title = @Title, Description = @Description, Time = @Time, ImageName = @ImageName, ImageType = @ImageType WHERE id = @id;";
                else
                    cmd.CommandText = @"UPDATE Movie set Title = @Title, Description = @Description, Time = @Time WHERE id = @id;";

                if (m.Image != null)
                {
                    cmd.Parameters.AddWithValue("@Image", m.Image);
                    cmd.Parameters.AddWithValue("@ImageName", m.ImageName);
                    cmd.Parameters.AddWithValue("@ImageType", m.ImageType);
                }
                cmd.Parameters.AddWithValue("@Title", m.Title);
                cmd.Parameters.AddWithValue("@Description", m.Description);
                cmd.Parameters.AddWithValue("@Time", m.Time);
                cmd.Parameters.AddWithValue("@Id", m.Id);
                cmd.ExecuteScalar();

                if (m.Image != null)
                {
                    string[] ext = m.ImageName.Split('.');
                    string extensio = string.Empty;
                    foreach (var item in ext)
                    {
                        extensio = item;
                    }

                    string filePath = AuxDAO.GetPathImage() + m.Id + "." + extensio;
                    File.WriteAllBytes(filePath, m.Image);
                }


                connection.Close();
            }
            catch (Exception ex)
            {
                return "Erro so atualizar o filme!!";
            }
            return "";
        }

        public Movie GetMovieById(object idMovie)
        {
            SqlConnection connection = new SqlConnection(AuxDAO.GetConnectionString());
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"select Id, Title, Description, Time, ImageName from Movie where Id = @Id;";
            cmd.Parameters.AddWithValue("@Id", idMovie);
            SqlDataReader rdr = cmd.ExecuteReader();
            Movie movie = new Movie();
            if (rdr.Read())
            {
                movie.Id = Convert.ToInt32(rdr["Id"]);
                movie.Title = Convert.ToString(rdr["Title"]);
                movie.Description = Convert.ToString(rdr["Description"]);
                movie.Time = Convert.ToInt32(rdr["Time"]);
                movie.ImageName = Convert.ToString(rdr["ImageName"]);
            }
            connection.Close();

            return movie;
        }

        public string AddMovie(Movie m)
        {
            try
            {
                SqlConnection connection = new SqlConnection(AuxDAO.GetConnectionString());
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"insert into Movie(Image, Title, Description, Time, ImageName, ImageType) values(@Image, @Title, @Description, @Time, @ImageName, @ImageType); SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("@Image", m.Image);
                cmd.Parameters.AddWithValue("@Title", m.Title);
                cmd.Parameters.AddWithValue("@Description", m.Description);
                cmd.Parameters.AddWithValue("@Time", m.Time);
                cmd.Parameters.AddWithValue("@ImageName", m.ImageName);
                cmd.Parameters.AddWithValue("@ImageType", m.ImageType);
                int identifier = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();

                string[] ext = m.ImageName.Split('.');
                string extensio = string.Empty;
                foreach (var item in ext)
                {
                    extensio = item;
                }

                string filePath = AuxDAO.GetPathImage() + identifier + "." + extensio;
                File.WriteAllBytes(filePath, m.Image);
            }
            catch (Exception ex)
            {
                return "Erro ao cadastrar filme!!";
            }

            return "";
        }

        public void DeleteMovie(int id)
        {
            SqlConnection connection = new SqlConnection(AuxDAO.GetConnectionString());
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"delete from Movie where id = @id;";
            cmd.Parameters.AddWithValue(@"@id", id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
