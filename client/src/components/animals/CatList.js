import { useState, useEffect } from "react";
import { getCats } from "../../managers/AnimalManager";

export default function CatList() {
    const [cats, setCats] = useState([]);

    const getAllCats = () => {
        getCats().then(setCats);
    };

    useEffect(() => {
        getAllCats();
    }, []);

    console.log(cats)
    return (
        <>
            <h2>Cats</h2>
            {cats.map((cat) => (
                <div key={cat.Id}>
                    <p>{cat.name}</p>
                    <img className="cat-picture" src={cat.urlPic} alt={cat.name} />
                </div>
            ))}
        </>
    );
}
