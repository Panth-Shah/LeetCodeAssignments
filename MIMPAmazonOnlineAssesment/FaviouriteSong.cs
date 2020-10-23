using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMPAmazonOnlineAssesment
{
    public class FaviouriteSong
    {
        public FaviouriteSong()
        {

        }
        public Dictionary<string, List<string>> faviouriteSong(Dictionary<string, List<string>> userMap, Dictionary<string, List<string>> genreMap)
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
            List<GenreOfSong> songByGenre = new List<GenreOfSong>();
            List<UserSong> songByUser = new List<UserSong>();

            List<string> GenreForUser = new List<string>();

            if(genreMap.Count <= 0 || genreMap == null)
            {
                foreach (var user in userMap)
                {
                    result[user.Key] = new List<string>();
                }

                return result;
            }

            //Build dictionary with Dict<song, Genre>
            foreach (var Genre in genreMap)
            {
                foreach (var song in Genre.Value)
                {

                    songByGenre.Add(new GenreOfSong { Genre = Genre.Key, Song = song});
                }
            }

            //Build dictionary with Dict<song, user>
            foreach (var user in userMap)
            {
                foreach (var song in user.Value)
                {
                    songByUser.Add(new UserSong { User = user.Key, Song = song});
                }
            }

            var ret = songByUser.Join(songByGenre,
                                        UserSong => UserSong.Song,
                                        GenreSong => GenreSong.Song,
                                        (UserSong, GenreSong) => new
                                        {
                                            UserSong.User,
                                            GenreSong.Genre
                                        });

            foreach (var obj in ret)
            {
                var GenreList = ret.Where(x => x.User == obj.User).Select(x => x.Genre).Distinct().ToList();
                if (!result.ContainsKey(obj.User))
                {
                    result[obj.User] = GenreList;
                }
            }

            return result;
        }
    }

    public class UserSong
    {
        public string Song { get; set; }
        public string User { get; set; }
    }

    public class GenreOfSong
    {
        public string Song { get; set; }
        public string Genre { get; set; }
    }
}
