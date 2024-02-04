using System;

// Define a Pet class to represent the virtual pet
class Pet
{
    // Properties of the pet
    public string Name { get; set; }
    public string Type { get; set; }
    public int Hunger { get; set; }
    public int Happiness { get; set; }
    public int Health { get; set; }
}

// Main program class
class Program
{
    // Entry point of the program
    static void Main()
    {
        // Display welcome message and prompt user to choose a pet type
        Console.WriteLine("Welcome to Virtual Pet Simulator!");
        Console.WriteLine("Choose a pet type:");
        Console.WriteLine("1. Cat");
        Console.WriteLine("2. Dog");
        Console.WriteLine("3. Rabbit");

        // Create a pet based on user input
        Pet myPet = CreatePet();

        // Main loop for interacting with the virtual pet
        while (true)
        {
            // Display the main menu
            DisplayMenu();

            // Get user input
            string userChoice = Console.ReadLine().Trim();

            // Check if user wants to exit
            if (userChoice.ToLower() == "exit" || userChoice == "5")
            {
                Console.WriteLine("Exiting the Virtual Pet Simulator. Goodbye!");
                break;
            }

            // Handle user's choice
            HandleUserChoice(userChoice, myPet);

            // Simulate the passage of time
            SimulateTimePassage(myPet);
        }
    }

    // Method to create a virtual pet based on user input
    static Pet CreatePet()
    {
        // Prompt user to choose a pet type
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine().ToLower().Trim();

        // Initialize variables for pet type and default to "Cat" if the choice is invalid
        string petType = "";

        switch (choice)
        {
            case "1":
                petType = "Cat";
                break;
            case "2":
                petType = "Dog";
                break;
            case "3":
                petType = "Rabbit";
                break;
            default:
                Console.WriteLine("Invalid choice. Defaulting to Cat.");
                petType = "Cat";
                break;
        }

        // Prompt user to enter the pet's name
        Console.Write($"Enter {petType}'s name: ");
        string petName = Console.ReadLine();

        // Create and return a new Pet object
        return new Pet { Name = petName, Type = petType, Hunger = 5, Happiness = 5, Health = 5 };
    }

    // Method to display the main menu
    static void DisplayMenu()
    {
        Console.WriteLine("\nMain Menu:");
        Console.WriteLine("1. Feed the pet");
        Console.WriteLine("2. Play with the pet");
        Console.WriteLine("3. Rest the pet");
        Console.WriteLine("4. Check pet status");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice: ");
    }

    // Method to handle user's choice and perform corresponding actions
    static void HandleUserChoice(string choice, Pet pet)
    {
        switch (choice)
        {
            case "1":
                FeedPet(pet);
                break;
            case "2":
                PlayWithPet(pet);
                break;
            case "3":
                RestPet(pet);
                break;
            case "4":
                // Check pet status
                DisplayPetStatus(pet);
                break;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
    }

    // Method to feed the pet
    static void FeedPet(Pet pet)
    {
        pet.Hunger = Math.Max(0, pet.Hunger - 2);
        pet.Health = Math.Min(10, pet.Health + 1);
        Console.WriteLine($"{pet.Name} has been fed. Hunger decreased, health increased.");
    }

    // Method to play with the pet
    static void PlayWithPet(Pet pet)
    {
        pet.Happiness = Math.Min(10, pet.Happiness + 2);
        pet.Hunger = Math.Max(0, pet.Hunger + 1);
        Console.WriteLine($"{pet.Name} enjoyed playing. Happiness increased, hunger slightly increased.");
    }

    // Method to rest the pet
    static void RestPet(Pet pet)
    {
        pet.Health = Math.Min(10, pet.Health + 2);
        pet.Happiness = Math.Max(0, pet.Happiness - 1);
        Console.WriteLine($"{pet.Name} had a good rest. Health increased, happiness decreased slightly.");
    }

    // Method to display the pet's status
    static void DisplayPetStatus(Pet pet)
    {
        Console.WriteLine($"\n--- {pet.Name}'s Status ---");
        Console.WriteLine($"Type: {pet.Type}");
        Console.WriteLine($"Hunger: {pet.Hunger}/10");
        Console.WriteLine($"Happiness: {pet.Happiness}/10");
        Console.WriteLine($"Health: {pet.Health}/10");

        // Display warnings for critically low stats
        if (pet.Hunger <= 2)
            Console.WriteLine("Warning: Hunger is critically low!");
        if (pet.Happiness <= 2)
            Console.WriteLine("Warning: Happiness is critically low!");
        if (pet.Health <= 2)
            Console.WriteLine("Warning: Health is critically low!");
    }

    // Method to simulate the passage of time
    static void SimulateTimePassage(Pet pet)
    {
        pet.Hunger = Math.Min(10, pet.Hunger + 1);
        pet.Happiness = Math.Max(0, pet.Happiness - 1);
    }
}

