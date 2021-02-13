using Songs.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SingASong.Domain
{
    public class Song
    {
        private List<string> animalList;
        private List<AnimalRhyme> animalRymeList;

        public Guid Id { get; }
        public Song(Guid id)
        {
            this.Id = id;
            animalList = new List<string>();
            animalRymeList = new List<AnimalRhyme>();
        }
        public void AddAnimals(List<string> animalList)
        {
            CheckAnimalList(animalList);
            this.animalList = animalList;
        }
        public void AddRhymes(List<AnimalRhyme> animalRymeList)
        {
            CheckAnimalList(animalRymeList);
            this.animalRymeList = animalRymeList;
        }
        public string GetLyrics()
        {
            if (IsEmpty(animalRymeList))
            {
                throw new ArgumentException($"{nameof(Song)} cannot {nameof(GetLyrics)} on an empty {nameof(animalList)}");
            }
            if (IsUnkownAnimalInRhyme(animalRymeList))
            {
                throw new ArgumentException($"{nameof(Song)} cannot {nameof(GetLyrics)} on an empty {nameof(animalRymeList)}");
            }
            var lyrics = new Lyrics(animalList, animalRymeList);
            return lyrics.Song;
        }
        
        private void CheckAnimalList(List<AnimalRhyme> animalRymeList)
        {
            if (IsEmpty(animalRymeList))
            {
                throw new ArgumentException($"{nameof(Song)} cannot have an empty {nameof(animalList)} when {nameof(AddRhymes)}");
            }
            if (IsUnkownAnimalInRhyme(animalRymeList))
            {
                throw new ArgumentException($"All {nameof(AnimalRhyme)} in a song {nameof(Song)} must be of animals in {nameof(animalList)}");
            }

        }

        private bool IsUnkownAnimalInRhyme(List<AnimalRhyme> animalRymeList)=>
            animalRymeList
            .All(an => animalRymeList.Contains(an));

        private void CheckAnimalList(List<string> animalList)
        {
            if(animalList == null || IsEmpty(animalList))
            {
                throw new ArgumentException($"{nameof(Song)} cannot have an empty {nameof(animalList)} when {nameof(AddAnimals)}");
            }
        }
        private bool IsEmpty(IEnumerable<object> list) =>
            !animalList.Any();
    }
}
