import { useState, useEffect } from "react";
import { getDogs, getFosteredDogs } from "../../managers/AnimalManager";
import "./Animal.css"


export default function DogList() {
    const [dogs, setDogs] = useState([]);
    const [filteredFostered, setFilteredFostered] = useState([]);
    const [displayFostered, setDisplayFostered] = useState(false);

    const getAllDogs = () => {
        getDogs().then(setDogs);
    };

    const getFosterDogs = () => {
        getFosteredDogs().then(setFilteredFostered);
    };

    const handleButtonClick = () => {
        setDisplayFostered(!displayFostered);
        document.getElementById("fostered").classList.toggle("clicked");
    };

    useEffect(() => {
        getAllDogs();
    }, []);

    useEffect(() => {
        getFosterDogs();
    }, []);

    console.log("All Available dogs", dogs);
    console.log("All Fostered dogs", filteredFostered);

    return (
        <>
            <h2>Available Dogs</h2>
            <div>
                <button id="fostered" onClick={handleButtonClick}>
                    Fostered
                </button>
            </div>
            {displayFostered ? filteredFostered.map((dog) => (
                <div key={dog.id}>
                    <p>{dog.name}</p>
                    <img className="dog-picture" src={dog.urlPic} alt={dog.name} />
                </div>
            )) : dogs.map((dog) => (
                <div key={dog.id}>
                    <p>{dog.name}</p>
                    <img className="dog-picture" src={dog.urlPic} alt={dog.name} />
                </div>
            ))}
        </>
    );
}





