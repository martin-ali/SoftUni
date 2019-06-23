using System;
using System.Collections.Generic;

namespace _08_pet_clinics
{
    public class PetClinic
    {
        private Pet[] rooms;

        private int lastIndex;

        public PetClinic(string name, int roomsCount)
        {
            var roomsAreOdd = roomsCount % 2 == 1;
            if (roomsAreOdd == false)
            {
                throw new InvalidOperationException();
            }

            this.rooms = new Pet[roomsCount];
            this.Name = name;
            this.RoomsCount = roomsCount;
            this.lastIndex = (roomsCount / 2) + 1;
        }

        public string Name { get; set; }

        public int RoomsCount { get; set; }

        private IEnumerable<int> NextRooms()
        {
            var distance = 1;
            var room = (this.rooms.Length / 2) + 1;
            for (int parity = this.lastIndex; 0 <= room && room < this.rooms.Length; parity++)
            {
                // First left, then right
                yield return room;

                room += (parity % 2 == 0 ? distance : (distance * -1));

                distance += 1;
            }
        }

        public bool AddPet(Pet pet)
        {
            foreach (var current in this.NextRooms())
            {
                if (this.rooms[current] == null)
                {
                    this.rooms[current] = pet;
                    return true;
                }
            }

            return false;
        }

        public bool ReleasePet()
        {
            return true;
        }

        public bool HasEmptyRooms()
        {
            return true;
        }

        // public
    }
}