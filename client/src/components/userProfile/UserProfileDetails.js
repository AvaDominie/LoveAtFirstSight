import { useEffect, useState } from "react";
import { getUserProfileById } from "../../managers/UserProfileManager";
import { Link } from "react-router-dom";



export default function UserProfileDetails({ loggedInUser }) {
    const [user, setUser] = useState(null);


    const getUserId = loggedInUser.id
    console.log("user id", getUserId)


    useEffect(() => {
        getUserProfileById(getUserId).then(setUser);
    }, [getUserId]);



    console.log("user name", user)

    return (
        <div>
            <h2>User Profile Details</h2>
            {user ? (
                <>
                    <p>Full Name: {user.fullName}</p>
                    <p>Email: {user.email}</p>
                    <p>Address: {user.address}</p>

                    <h3>Adopted Animals:</h3>
                    {user.adoptions && user.adoptions.length > 0 ? (
                        <ul>
                            {user.adoptions.map((adoption) => (
                                <li key={adoption.id}>
                                    <p>Name: {adoption.animal.name}</p>
                                    <Link to={`/animalDetails/${adoption.animal.id}`} >
                                    <p><img src={adoption.animal.urlPic} alt={adoption.animal.name} /></p>
                                    </Link>
                                </li>
                            ))}
                        </ul>
                    ) : (
                        <p>No adopted animals.</p>
                    )}
                </>
            ) : (
                <p>Loading...</p>
            )}
        </div>
    );
}