import { Link } from "react-router-dom";
import DogList from "./DogList";


export default function Dogs({ loggedInUser }) {
    // Check if the user has the "Employee" role
    const isEmployee = loggedInUser?.roles?.includes("Employee");

    return (
        <div className="container">
            <div className="row">
                <div className="">
                    {isEmployee && (
                        <Link to={`/addAnimal`}>
                            <button>Add Dog</button>
                        </Link>
                    )}
                    <DogList />
                </div>
            </div>
        </div>
    );
}





