﻿using Song.Sections;
using Songs.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SingASong.Domain
{
    public class Lyrics
    {
        private const int ANIMAL_COUNT = 7;
        private List<string> animalCollection;
        private readonly List<AnimalRhyme> animalRymeList;

        public string Song { get; }
        public Lyrics(List<string> animalCollection, List<AnimalRhyme> animalRymeList)
        {
            if (animalCollection.Count != ANIMAL_COUNT)
            {
                throw new ArgumentException($"{nameof(animalCollection)} must be {ANIMAL_COUNT} items long");
            }
            this.animalCollection = animalCollection;
            this.animalRymeList = animalRymeList;
            Song = ComposeSong();

        }

        public string ComposeSong()
        {
            var joinedSections = GetStart();
            var composingAnimals = animalCollection
                .Take(animalCollection.Count - 1)
                .ToList();
            for (int i = 1; i < composingAnimals.Count; i++)
            {
                var animal = composingAnimals[i];
                var currRhyme = animalRymeList.FirstOrDefault(x => x.Animal == animal);
                if (currRhyme == null)
                {
                    currRhyme = AnimalRhyme.Empty;
                }
                var processingAnimalList = composingAnimals.GetRange(0, i + 1);
                var currSection = currRhyme.Equals(animalRymeList.First())
                    ? Section.Create(processingAnimalList, currRhyme, ".")
                    : Section.Create(processingAnimalList, currRhyme);
                joinedSections += "\n" + currSection.Value;
            }
            joinedSections += "\n" + new LyricsEnding(animalCollection.Last()).Value;
            return joinedSections;
        }


        public string GetStart()
        {
            var firstAnimal = animalCollection.First();
            return Section.Create(firstAnimal)
                .Value;
        }
    }
}