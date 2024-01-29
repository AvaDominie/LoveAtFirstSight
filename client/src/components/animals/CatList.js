import { useState, useEffect } from "react";
import { getCats, getCatsByBreed, getFosteredCats, getFosteredCatsByBreed } from "../../managers/AnimalManager";
import "./Animal.css"
import { getCatBreeds } from "../../managers/BreedManager";
import { Link } from "react-router-dom";


export default function CatList() {
    const [cats, setCats] = useState([]);
    const [filteredFostered, setFilteredFostered] = useState([]);
    const [displayFostered, setDisplayFostered] = useState(false);
    const [breeds, setBreeds] = useState([]);
    const [selectedBreed, setSelectedBreed] = useState("");




    const getAllCats = () => {
        getCats().then(setCats);
    };

    const getFosterCats = () => {
        getFosteredCats().then(setFilteredFostered);
    };

    const getCatBreed = () => {
        getCatBreeds().then(setBreeds)
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
        getAllCats();
    }, []);

    useEffect(() => {
        if (selectedBreed !== "") {
            getFosteredCatsByBreed(selectedBreed).then(setFilteredFostered);
        } else {
            getFosterCats();
        }
    }, [selectedBreed]);
    
    useEffect(() => {
        getCatBreed();
    }, []);

    useEffect(() => {
        if (selectedBreed !== "") {
            getCatsByBreed(selectedBreed).then(setCats);
        } else {
            getAllCats();
        }
    }, [selectedBreed]);


    return (
        <>
            <h2>Available Cats</h2>
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
            {displayFostered ? filteredFostered.map((cat) => (
                <div key={cat.id}>
                    <p>{cat.name}</p>
                    <Link to={`/animalDetails/${cat.id}`} >
                    <img className="cat-picture" src={cat.urlPic} alt={cat.name} />
                    </Link>
                </div>
            )) : cats.map((cat) => (
                <div key={cat.id}>
                    <p>{cat.name}</p>
                    <Link to={`/animalDetails/${cat.id}`} >
                    <img className="cat-picture" src={cat.urlPic} alt={cat.name} />
                    </Link>
                </div>
            ))}
        </>
    );
}






