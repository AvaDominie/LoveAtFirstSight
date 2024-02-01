import { Link } from "react-router-dom";
import CatList from "./CatList";


export default function Cats({ loggedInUser }) {
    // Check if the user has the "Employee" role
    const isEmployee = loggedInUser?.roles?.includes("Employee");

    return (
        <div className="container">
            <div className="row">
                <div className="">
                    {isEmployee && (
                        <Link to={`/addAnimal`}>
                            <button>Add Cat</button>
                        </Link>
                    )}
                    <CatList />
                </div>
            </div>
        </div>
    );
}
