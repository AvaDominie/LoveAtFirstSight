import { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getAnimalById, updateAnimal } from "../../managers/AnimalManager";
import { getAllBreeds } from "../../managers/BreedManager";
import "./Animal.css"

export default function EditAnimal() {
    const { animalId } = useParams();
    const [animal, setAnimal] = useState(null);
    const [animalType, setAnimalType] = useState("");
    const [gender, setGender] = useState("");
    const [name, setName] = useState("");
    const [age, setAge] = useState("");
    const [urlPic, setUrlPic] = useState("");
    const [selectedBreeds, setSelectedBreeds] = useState([]);
    const [breeds, setBreeds] = useState([]);

    const navigate = useNavigate();

    useEffect(() => {
        // Fetch animal details by id and set the state
        getAnimalById(animalId).then((animalData) => {
            setAnimal(animalData);
            setAnimalType(animalData.animalType);
            setGender(animalData.gender);
            setName(animalData.name);
            setAge(animalData.age);
            setUrlPic(animalData.urlPic);
        });

        // Fetch all breeds for the dropdown
        getAllBreeds().then(setBreeds);
    }, [animalId]);
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
        setSelectedBreeds([...selectedBreeds, breedId]);
    };

    const handleSubmit = (event) => {
        event.preventDefault();


        var isMale = gender;
        if (isMale === "male") {
            isMale = true;
        } else {
            isMale = false
        }
        var isDog = animalType;
        if (isDog === "dog") {
            isDog = true;
        } else {
            isDog = false
        }

        var animalBreeds = selectedBreeds.map((animalBreed) => {
            return { "breedId": animalBreed };
        })

        const updatedAnimal = {
            isDog,
            isMale,
            name,
            age,
            urlPic,
            animalBreeds,
        };
        console.log("animalbreed", animalBreeds)
        // Call the updateAnimal function to send the data to the server
        updateAnimal(animalId, updatedAnimal)
            .then((response) => {
                if (response.ok) {
                    // Handle success 
                    console.log("Animal updated successfully!");
                } else {
                    // Handle errors 
                    console.error("Failed to update the animal.");
                }
                console.log("updated animal", updatedAnimal)
            })
            .catch((error) => {
                // Handle unexpected errors
                console.error("An unexpected error occurred:", error);
            });
        navigate(`/`)
    };
    console.log("animal", animal)
    return (
        <div className="container">
            <div className="animal-edit-details">
                <h2>Edit Animal Form</h2>
                <hr />
                {animal ? (
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
                                            <option key={breed.id} value={breed.id} className={selectedBreeds.includes(breed.id) ? "selected-breed" : ""}>
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
                        <button id="submit-animal" type="submit">Update</button>
                    </form>
                ) : (
                    <p>Loading animal details...</p>
                )}
            </div>
        </div>
    );
}

