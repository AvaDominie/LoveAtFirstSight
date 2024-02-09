

import { useEffect, useState } from "react"
import { deleteAnimal, deleteAnimalFostered, getAnimalById, updateAnimalAvailability, updateAnimalFostered } from "../../managers/AnimalManager";
import { Link, useNavigate, useParams } from "react-router-dom";
import { createAdoption, createFoster, deleteFoster } from "../../managers/AdoptManager";


export default function AnimalDetails({ loggedInUser }) {
    const [animal, setAnimal] = useState(null);
    const [hasAdopted, setHasAdopted] = useState(false);
    const { animalId } = useParams();
    const navigate = useNavigate();

    const getAnimalDetails = (id) => {
        getAnimalById(id).then(setAnimal);
    }

    const handleAdopt = () => {
        if (!hasAdopted) {
            createAdoption(animalId, loggedInUser.id);
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

    const handleDelete = () => {
        deleteAnimal(animalId);
        navigate(`/`)
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
    console.log(loggedInUser)
    return (
        <>
            <div className="animal">
                <h2 className="animal-details-title">Animal details</h2>
                <hr />
                <div className="animal-detail-container">
                    <div className="animal-item">
                        <img className="animal-detail-picture" src={animal.urlPic} alt={animal.name} />
                    </div>
                    <div className="animal-item animal-details">
                        <p>Name: {animal.name}</p>
                        <p>Breed/s: {breedsString}</p>
                        <p>Age: {animal.age} months</p>
                        <p>Date Added: {new Date(animal.dateAdded).toLocaleDateString('en-CA')}</p>
                        <p>Currently being Fostered: {animal.fostered ? 'Yes' : 'No'}</p>
                        <p>Adopted: {animal.available ? 'No' : 'Yes'}</p>

                        {!loggedInUser?.roles?.includes("Employee") && (
                            <div>
                                <button id="adoption" onClick={handleAdopt} disabled={hasAdopted} style={{ marginRight: '10px' }}>Adopt</button>
                                <button id="foster" onClick={handleFoster} style={{ marginRight: '10px' }}>Foster</button>
                                <div style={{ marginTop: '20px' }}>
                                    <button id="return-foster" onClick={handleDeleteFoster} style={{ marginRight: '10px' }}>Return Foster</button>
                                </div>
                            </div>
                        )}
                        {loggedInUser?.roles?.includes("Employee") && (
                            <div>
                                <Link to={`/editAnimal/${animal.id}`}>
                                    <button id="edit-animal">Edit</button>
                                </Link>
                                <button id="delete-animal" onClick={handleDelete}>Delete</button>
                            </div>
                        )}
                    </div>
                </div>
            </div>
        </>
    );
}



