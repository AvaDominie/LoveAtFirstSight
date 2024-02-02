import { useEffect, useState } from "react"
import { deleteAnimalFostered, getAnimalById, updateAnimalAvailability, updateAnimalFostered } from "../../managers/AnimalManager";
import { Link, useParams } from "react-router-dom";
import { createAdoption, createFoster, deleteFoster } from "../../managers/AdoptManager";




export default function AnimalDetails({ loggedInUser }) {
    const [animal, setAnimal] = useState(null);
    const [hasAdopted, setHasAdopted] = useState(false);
    const { animalId } = useParams();

    const isEmployee = loggedInUser?.roles?.includes("Employee");
    const isUser = loggedInUser?.roles?.includes("User");


    const getAnimalDetails = (id) => {
        getAnimalById(id).then(setAnimal);
    }

    const handleAdopt = () => {
        // Check if the animal has not been adopted already
        if (!hasAdopted) {
            createAdoption(animalId, loggedInUser.id);
            // Set the state to indicate that the animal has been adopted
            updateAnimalAvailability(animalId);
            setHasAdopted(true);
        }
    }

    const handleFoster = () => {
        createFoster(animalId, loggedInUser.id);
        updateAnimalFostered(animalId);
    }

    const handleDeleteFoster = () => {
        deleteFoster(loggedInUser.id, animalId);
        deleteAnimalFostered(animalId);
    }





    useEffect(() => {
        console.log("user", loggedInUser)
    }, [loggedInUser])

    useEffect(() => {
        if (animalId) {
            getAnimalDetails(animalId);
        }
    }, [animalId])



    if (!animal) {
        return (
            <>
                <h2>Animal Details</h2>
                <p>Please choose an Animal...</p>
            </>
        );
    }

    const breedsArray = animal.animalBreeds.map(animalBreed => animalBreed.breed.name);
    const breedsString = breedsArray.join(", ");
    console.log("animal", animal)

    return (
        <>
            <h2>Animal details</h2>
            <div>
                <img className="animal-picture" src={animal.urlPic} alt={animal.name} />
                <p>Name: {animal.name}</p>
                <p>Breed/s: {breedsString}</p>
                <p>Age: {animal.age} months</p>
                <p>Date Added: {new Date(animal.dateAdded).toLocaleDateString('en-CA')}</p>
                <p>Currently being Fostered: {animal.fostered ? 'Yes' : 'No'}</p>
                <p>Adopted: {animal.available ? 'No' : 'Yes'}</p>
                {isUser && (
                    <div>
                        <button onClick={handleAdopt} disabled={hasAdopted}>Adopt</button>
                        <button onClick={handleFoster}>Foster</button>
                        <button onClick={handleDeleteFoster}>Return Foster</button>
                    </div>
                )}
                {isEmployee && (
                    <div>
                        <Link to={`/editAnimal/${animal.id}`}>
                            <button>Edit</button>
                        </Link>
                        <button onClick={handleAdopt}>Delete</button>
                    </div>
                )}
            </div>
        </>
    );
}



