import React, { useEffect, useState } from "react";
import { getUserProfileById } from "../../managers/UserProfileManager";
import { Link } from "react-router-dom";

export default function UserProfileDetails({ loggedInUser }) {
    const [user, setUser] = useState(null);
    
    let uniqueAnimalIds = [];

    const getUserId = loggedInUser.id;

    useEffect(() => {
        getUserProfileById(getUserId).then(setUser);
    }, [getUserId]);

    console.log(user)

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
                                !adoption.animal.available && (
                                    <li key={adoption.id}>
                                        <p>Name: {adoption.animal.name}</p>
                                        <Link to={`/animalDetails/${adoption.animal.id}`} >
                                            <p><img src={adoption.animal.urlPic} alt={adoption.animal.name} /></p>
                                        </Link>
                                    </li>
                                )
                            ))}
                        </ul>
                    ) : (
                        <p>No adopted animals.</p>
                    )}

                    <h3>Fostered Animals:</h3>
                    {user.adoptions && user.adoptions.length > 0 ? (
                        <ul>
                            {user.adoptions.map((adoption) => (
                                // Check if the animal is available, in foster, and not in the array
                                adoption.animal.available && adoption.foster && !uniqueAnimalIds.includes(adoption.animal.id) && (
                                    // Add the animal ID to the array
                                    uniqueAnimalIds.push(adoption.animal.id),
                                    <li key={adoption.id}>
                                        <p>Name: {adoption.animal.name}</p>
                                        <Link to={`/animalDetails/${adoption.animal.id}`}>
                                            <p><img src={adoption.animal.urlPic} alt={adoption.animal.name} /></p>
                                        </Link>
                                    </li>
                                )
                            ))}
                        </ul>
                    ) : (
                        <p>No fostered animals.</p>
                    )}
                </>
            ) : (
                <p>Loading...</p>
            )}
        </div>
    );
}
