import { Link } from "react-router-dom";
import CatList from "./CatList";
import { useState, useEffect } from "react";

export default function Cats({ loggedInUser }) {
    // check if the user has the "Employee" role
    const isEmployee = loggedInUser?.roles?.includes("Employee");

    // State to track whether the user is at the top of the page or not
    const [isAtTop, setIsAtTop] = useState(true);

    // Function to check if the user has scrolled to the top of the page
    const handleScroll = () => {
        const scrollTop = window.pageYOffset;
        setIsAtTop(scrollTop === 0);
    };

    // Function to scroll to the top of the page
    const scrollToTop = () => {
        window.scrollTo({
            top: 0,
            behavior: "smooth"
        });
    };

    // Add event listener for scrolling when component mounts
    useEffect(() => {
        window.addEventListener("scroll", handleScroll);
        return () => {
            window.removeEventListener("scroll", handleScroll);
        };
    }, []);

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
                    {!isAtTop && (
                        <div className="back-to-top" onClick={scrollToTop}>
                            <span>&#8593;</span>
                        </div>
                    )}
                </div>
            </div>
        </div>
    );
}