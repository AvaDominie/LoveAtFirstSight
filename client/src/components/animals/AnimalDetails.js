import { useEffect, useState } from "react"
import { getAnimalById } from "../../managers/AnimalManager";
import { useParams } from "react-router-dom";



export default function AnimalDetails() {
    const [animal, setAnimal] = useState(null);
    const { animalId } = useParams();

    const getAnimalDetails = (id) => {
        getAnimalById(id).then(setAnimal);
    }

    
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

    console.log(animal.animalBreeds)
    console.log("breed", animal.animalBreeds.breed)

    return (
        <>
            <h2>Animal details</h2>
            <div>
                <img className="animal-picture" src={animal.urlPic} alt={animal.name} />
                <p>Name: {animal.name}</p>
                <p>Breed/s: {breedsString}</p>
                <p>Age: {animal.age}</p>
                <p>Date Added: {new Date(animal.dateAdded).toLocaleDateString('en-CA')}</p>
                <p>Currently being Fostered: {String(animal.fostered)}</p>
                <p>Adopted: {String(animal.available)}</p>
            </div>
        </>
    );

}
// {animal.animalBreeds.map((animalBreed) => (
//     <p key={animalBreed.id}>Breed: {animalBreed.breed.name}</p>
// ))}