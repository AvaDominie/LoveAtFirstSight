import { Link } from "react-router-dom";
import DogList from "./DogList";

export default function Dogs({ loggedInUser }) {

    // check if the user has the "Employee" role
    const isEmployee = loggedInUser?.roles?.includes("Employee");

    // function to scroll to the top of the page
    const scrollToTop = () => {
        window.scrollTo({
            top: 0,
            behavior: "smooth"
        });
    };

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
                    
                    <div className="back-to-top" onClick={scrollToTop}>
                        Back to Top
                    </div>
                </div>
            </div>
        </div>
    );
}




