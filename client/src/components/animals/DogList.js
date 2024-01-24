import { useState, useEffect } from "react";
import { getDogs } from "../../managers/AnimalManager";

export default function DogList() {
    const [dogs, setDogs] = useState([]);

    const getAllDogs = () => {
        getDogs().then(setDogs);
    };

    useEffect(() => {
        getAllDogs();
    }, []);

    console.log(dogs)
    return (
        <>
            <h2>Dogs</h2>
            {dogs.map((dog) => (
                <div key={dog.Id}>
                    <p>{dog.name}</p>
                    <img className="dog-picture" src={dog.urlPic} alt={dog.name} />
                </div>
            ))}
        </>
    );
}
