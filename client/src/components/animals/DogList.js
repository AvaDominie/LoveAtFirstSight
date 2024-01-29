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
    }, []);

    useEffect(() => {
        if (selectedBreed !== "") {
            getFosteredDogsByBreed(selectedBreed).then(setFilteredFostered);
        } else {
            getFosterDogs();
        }
    }, [selectedBreed]);

    useEffect(() => {
        getDogBreed();
    }, []);

    useEffect(() => {
        if (selectedBreed !== "") {
            getDogsByBreed(selectedBreed).then(setDogs);
        } else {
            getAllDogs();
        }
    }, [selectedBreed]);


    console.log("All Available dogs", dogs);
    console.log("All Fostered dogs", filteredFostered);
    console.log("All Breeds", breeds)
    console.log("Selected breeds", selectedBreed)


    return (
        <>
            <h2>Available Dogs</h2>
            <div>
                <button id="fostered" onClick={handleButtonClick}>
                    Fostered
                </button>
                <select onChange={(e) => setSelectedBreed(e.target.value)}>
                    <option value="">All breeds</option>
                    {breeds.map((breed) => (
                        <option key={breed.id} value={breed.name}>
                            {breed.name}
                        </option>
                    ))}
                </select>
            </div>
            {displayFostered ? filteredFostered.map((dog) => (
                <div key={dog.id}>
                    <p>{dog.name}</p>
                    <Link to={`/animalDetails/${dog.id}`} >
                        <img className="dog-picture" src={dog.urlPic} alt={dog.name} />
                    </Link>
                </div>
            )) : dogs.map((dog) => (
                <div key={dog.id}>
                    <p>{dog.name}</p>
                    <Link to={`/animalDetails/${dog.id}`} >
                        <img className="dog-picture" src={dog.urlPic} alt={dog.name} />
                    </Link>
                </div>
            ))}
        </>
    );
}





