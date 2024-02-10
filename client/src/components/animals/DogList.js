import { useState, useEffect } from "react";
import { getDogs, getDogsByBreed, getFosteredDogs, getFosteredDogsByBreed } from "../../managers/AnimalManager";
import "./Animal.css"
import { getDogBreeds } from "../../managers/BreedManager";
import { Link } from "react-router-dom";


export default function DogList() {
    const [dogs, setDogs] = useState([]);
    const [filteredFostered, setFilteredFostered] = useState([]);
    const [displayFostered, setDisplayFostered] = useState(false);
    const [breeds, setBreeds] = useState([]);
    const [selectedBreed, setSelectedBreed] = useState("");

    console.log("all dogs", dogs)
    const getAllDogs = () => {
        getDogs().then(setDogs);
    };

    const getFosterDogs = () => {
        getFosteredDogs().then(setFilteredFostered);
    };

    const getDogBreed = () => {
        getDogBreeds().then(setBreeds)
    }

    const handleButtonClick = () => {
        setDisplayFostered(!displayFostered);
        document.getElementById("fostered").classList.toggle("clicked");
    };

    const handleBreedChange = (event) => {
        const breed = event.target.value;
        setSelectedBreed(breed);
    };

    useEffect(() => {
        getAllDogs();
        getFosterDogs();
        getDogBreed();
    }, []);

    useEffect(() => {
        if (selectedBreed !== "") {
            getFosteredDogsByBreed(selectedBreed).then(setFilteredFostered);
        } else {
            getFosterDogs();
        }
    }, [selectedBreed]);

    useEffect(() => {
        if (selectedBreed !== "") {
            getDogsByBreed(selectedBreed).then(setDogs);
        } else {
            getAllDogs();
        }
    }, [selectedBreed]);

    return (
        <>
            <h2 className="animal-details-title">Available Dogs</h2>
            <hr />
            <div>
                <button id="fostered" onClick={handleButtonClick}>
                    Fostered
                </button>
                <br />
                <br />
                <select onChange={(e) => setSelectedBreed(e.target.value)}>
                    <option value="">All breeds</option>
                    {breeds.map((breed) => (
                        <option key={breed.id} value={breed.name}>
                            {breed.name}
                        </option>
                    ))}
                </select>
            </div>
            <div className="animal-container">
                {displayFostered ? filteredFostered.map((dog) => (
                    <div key={dog.id} className="animal-item">
                        <p>{dog.name}</p>
                        <Link to={`/animalDetails/${dog.id}`} >
                            <img className="animal-picture" src={dog.urlPic} alt={dog.name} />
                        </Link>
                    </div>
                )) : dogs.map((dog) => (
                    <div key={dog.id} className="animal-item">
                        <p>{dog.name}</p>
                        <Link to={`/animalDetails/${dog.id}`} >
                            <img className="animal-picture" src={dog.urlPic} alt={dog.name} />
                        </Link>
                    </div>
                ))}
            </div>
        </>
    );
}
