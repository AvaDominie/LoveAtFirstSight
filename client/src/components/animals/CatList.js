import { useState, useEffect } from "react";
import { getCats, getFosteredCats } from "../../managers/AnimalManager";
import "./Animal.css"

export default function CatList() {
    const [Cats, setCats] = useState([]);
    const [filteredFostered, setFilteredFostered] = useState([])
    const [displayFostered, setDisplayFostered] = useState(false);



    const getAllCats = () => {
        getCats().then(setCats);
    };

    const getFosterCats = () => {
        getFosteredCats().then(setFilteredFostered);
    };

    const handleButtonClick = () => {
        setDisplayFostered(!displayFostered);
        document.getElementById("fostered").classList.toggle("clicked");
    };


    useEffect(() => {
        getAllCats();
    }, []);

    useEffect(() => {
        getFosterCats();
    }, []);

    console.log("All Avalible Cats", Cats)

    console.log("All Fostered Cats", filteredFostered)


    return (
        <>
            <h2>Available Cats</h2>
            <div>
                <button id="fostered" onClick={handleButtonClick}>
                    Fostered
                </button>
            </div>
            {displayFostered ? filteredFostered.map((cat) => (
                <div key={cat.id}>
                    <p>{cat.name}</p>
                    <img className="cat-picture" src={cat.urlPic} alt={cat.name} />
                </div>
            )) : Cats.map((cat) => (
                <div key={cat.id}>
                    <p>{cat.name}</p>
                    <img className="cat-picture" src={cat.urlPic} alt={cat.name} />
                </div>
            ))}
        </>
    );
}

