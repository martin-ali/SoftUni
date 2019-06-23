using System;
using System.Collections.Generic;

namespace _08_pet_clinics
{
    public class PetClinicManager
    {
        private Dictionary<string, Pet> petByName = new Dictionary<string, Pet>();

        private Dictionary<string, PetClinic> clinicByName = new Dictionary<string, PetClinic>();

        public string ParseCommand(string command)
        {
            var parameters = command.Split();

            try
            {
                if (command.Contains("Create Pet"))
                {
                    var name = parameters[2];
                    var age = int.Parse(parameters[3]);
                    var kind = parameters[4];

                    var pet = CreatePet(name, age, kind);

                    petByName[name] = pet;

                    return true.ToString();
                }
                else if (command.Contains("Create Clinic"))
                {
                    var name = parameters[2];
                    var roomsCount = int.Parse(parameters[3]);

                    var clinic = CreateClinic(name, roomsCount);

                    clinicByName[name] = clinic;
                }
                else if (command.Contains("Add"))
                {
                    var petName = parameters[1];
                    var clinicName = parameters[2];

                    var pet = this.petByName[petName];
                    var clinic = this.clinicByName[clinicName];

                    return clinic.AddPet(pet).ToString();
                }
                else if (command.Contains("Release"))
                {
                    var clinicName = parameters[1];
                    var clinic = this.clinicByName[clinicName];

                    return clinic.ReleasePet().ToString();
                }
                else if (command.Contains("HasEmptyRooms"))
                {
                    var clinicName = parameters[1];
                    var clinic = this.clinicByName[clinicName];

                    return clinic.HasEmptyRooms().ToString();
                }
                else if (command.Contains("Print") && parameters.Length == 2)
                {
                    var clinicName = parameters[1];
                    var clinic = this.clinicByName[clinicName];
                }
                else if (command.Contains("Print"))
                {
                    var clinicName = parameters[1];
                    var clinic = this.clinicByName[clinicName];
                }
            }
            catch (System.Exception)
            {
                throw new InvalidOperationException("Invalid operation!");
            }

            return null;
        }

        private Pet CreatePet(string name, int age, string kind)
        {
            return new Pet(name, age, kind);
        }

        private PetClinic CreateClinic(string name, int roomsCount)
        {
            return new PetClinic(name, roomsCount);
        }

        private bool AddPetToClinic(Pet pet, PetClinic clinic)
        {
            return true;
        }

        private bool ReleasePetFromClinic(PetClinic clinic)
        {
            return true;
        }

        private bool ClinicHasEmptyRooms(PetClinic clinic)
        {
            return true;
        }

        private string PrintClinic(PetClinic clinic)
        {
            return string.Empty;
        }

        private string PrintClinicRoom(PetClinic clinic)
        {
            return string.Empty;
        }
    }
}