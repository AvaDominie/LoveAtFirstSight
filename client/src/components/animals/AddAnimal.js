import { useEffect, useState } from "react";
import { getAllBreeds } from "../../managers/BreedManager";
import { addAnimal } from "../../managers/AnimalManager";



export default function AddAnimal() {
    const [animalType, setAnimalType] = useState("dog");
    const [gender, setGender] = useState("male");
    const [name, setName] = useState("");
    const [age, setAge] = useState("");
    const [urlPic, setUrlPic] = useState("");
    const [animalBreeds, setAnimalBreeds] = useState([]);
    const [breeds, setBreeds] = useState()



    const handleAnimalTypeChange = (event) => {
        setAnimalType(event.target.value);
    };

    const handleGenderChange = (event) => {
        setGender(event.target.value);
    };

    const handleNameChange = (event) => {
        setName(event.target.value);
    };

    const handleAgeChange = (event) => {
        setAge(event.target.value);
    };

    const handleUrlPicChange = (event) => {
        setUrlPic(event.target.value);
    };

    const handleBreedChange = (event) => {
        const breedId = parseInt(event.target.value);
        
        
    
        setAnimalBreeds([...animalBreeds, {breedId}]);
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        

        const addedAnimal = {
            animalType,
            gender,
            name,
            age,
            urlPic,
            animalBreeds
        };

        // Call the addAnimal function to send the data to the server
        addAnimal(addedAnimal)
            .then((response) => {
                if (response.ok) {
                    // Handle success 
                    console.log("Animal added successfully!");
                } else {
                    // Handle errors 
                    console.error("Failed to add the animal.");
                }
            })
            .catch((error) => {
                // Handle unexpected errors
                console.error("An unexpected error occurred:", error);
            });

        // Reset the form fields if needed
        setAnimalType("dog");
        setGender("male");
        setName("");
        setAge("");
        setUrlPic("");
        setAnimalBreeds([]);
    };


    useEffect(() => {
        getAllBreeds().then(setBreeds);
    }, [])

    console.log(breeds)

    return (
        <div>
            <h2>Add Animal Form</h2>
            <br />
            <form onSubmit={handleSubmit}>
                <label>
                    Animal Type:
                    <div>
                        <input
                            type="radio"
                            value="dog"
                            checked={animalType === "dog"}
                            onChange={handleAnimalTypeChange}
                        />
                        Dog
                        <input
                            type="radio"
                            value="cat"
                            checked={animalType === "cat"}
                            onChange={handleAnimalTypeChange}
                        />
                        Cat
                    </div>
                </label>
                <br />
                <br />
                <label>
                    Gender:
                    <div>
                        <input
                            type="radio"
                            value="male"
                            checked={gender === "male"}
                            onChange={handleGenderChange}
                        />
                        Male
                        <input
                            type="radio"
                            value="female"
                            checked={gender === "female"}
                            onChange={handleGenderChange}
                        />
                        Female
                    </div>
                </label>
                <br />
                <br />
                <label>
                    Name:
                    <input type="text" value={name} onChange={handleNameChange} />
                </label>
                <br />
                <br />
                <label>
                    Age:
                    <input type="text" value={age} onChange={handleAgeChange} />
                </label>
                <br />
                <br />
                <label>
                    URL Picture:
                    <input type="text" value={urlPic} onChange={handleUrlPicChange} />
                </label>
                <br />
                <br />
                <label>
                    Animal Breeds:
                    <div>
                        {breeds ? (
                            <select onChange={handleBreedChange} multiple>
                                {breeds.map((breed) => (
                                    <option key={breed.id} value={breed.id}>
                                        {breed.name}
                                    </option>
                                ))}
                            </select>
                        ) : (
                            <p>Loading breeds...</p>
                        )}

                    </div>
                </label>
                <br />
                <br />
                <button type="submit">Submit</button>
            </form>
        </div>
    );
}








