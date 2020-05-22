namespace _04_hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Department
    {
        private Room[] rooms = new Room[20];

        private int lastUsedRoomIndex = 0;

        public Department(string name)
        {
            this.Name = name;

            for (int current = 0; current < this.rooms.Length; current++)
            {
                this.rooms[current] = new Room();
            }
        }

        public string Name { get; private set; }

        public bool HasUnoccupiedBeds => this.lastUsedRoomIndex < this.rooms.Length
                                        && this.rooms.Any(r => r.HasEmptyBeds);

        public IReadOnlyList<Room> Rooms
        {
            get
            {
                return this.rooms
                        .ToList()
                        .AsReadOnly();
            }
        }

        public IReadOnlyCollection<Patient> Patients
        {
            get
            {
                return this.rooms
                        .Where(r => r?.OccupiedBedsCount > 0)
                        .SelectMany(r => r.Patients)
                        .ToList()
                        .AsReadOnly();
            }
        }

        public Room GetRoom(int number)
        {
            number -= 1;

            var roomExists = 0 <= number && number < this.rooms.Length;
            if (roomExists == false)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.rooms[number];
        }

        public void AddPatient(Patient patient)
        {
            var room = rooms[lastUsedRoomIndex];

            if (room.HasEmptyBeds == false)
            {
                lastUsedRoomIndex++;
            }

            room = rooms[lastUsedRoomIndex];
            room.AddPatient(patient);
        }
    }
}