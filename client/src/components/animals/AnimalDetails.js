import { useEffect, useState } from "react"
import { getAnimalById, updateAnimalAvailability } from "../../managers/AnimalManager";
import { useParams } from "react-router-dom";
import { createAdoption } from "../../managers/AdoptManager";



export default function AnimalDetails({ loggedInUser }) {
    const [animal, setAnimal] = useState(null);
    const { animalId } = useParams();


    const getAnimalDetails = (id) => {
        getAnimalById(id).then(setAnimal);
    }

    const handleAdopt = () => {
        createAdoption(animalId, loggedInUser.id);
        updateAnimalAvailability(animalId);
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
                <button onClick={handleAdopt}>Adopt</button>
                <button>Foster</button>
                <button>Return Foster</button>
            </div>
        </>
    );

}
