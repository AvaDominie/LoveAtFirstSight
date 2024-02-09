import React, { useEffect, useState } from "react";
import { getUserProfileById } from "../../managers/UserProfileManager";
import { Link } from "react-router-dom";
import "./UserProfile.css"

export default function UserProfileDetails({ loggedInUser }) {
    const [user, setUser] = useState(null);

    let uniqueAnimalIds = [];

    const getUserId = loggedInUser.id;

    useEffect(() => {
        getUserProfileById(getUserId).then(setUser);
    }, [getUserId]);

    console.log("user", user)

    return (
        <div className="container">
            
            
            {user ? (
                <>
                <div className="profile-details">
                <h2>Profile Details</h2>
                <hr />
                <br />
                    <p>Full Name: {user.fullName}</p>
                    <p>Username: {user.userName}</p>
                    <p>Email: {user.email}</p>
                    <p>Address: {user.address}</p>
                    </div>
                    <br />
                    <br />
                    {!loggedInUser.roles.includes("Employee") && (
                        <>
                            <h3>Adopted Animals:</h3>
                            <hr />
                            {user.adoptions && user.adoptions.length > 0 ? (
                                <ul>
                                    {user.adoptions.map((adoption) => (
                                        !adoption.animal.available && (
                                            <li key={adoption.id}>
                                                <p>{adoption.animal.name}</p>
                                                <Link to={`/animalDetails/${adoption.animal.id}`} >
                                                    <p><img className="animal-detail-picture" src={adoption.animal.urlPic} alt={adoption.animal.name} /></p>
                                                </Link>
                                            </li>
                                        )
                                    ))}
                                </ul>
                            ) : (
                                <p>No adopted animals.</p>
                            )}
                            <br />
                            <br />
                            <br />
                            <h3>Fostered Animals:</h3>
                            <hr />
                            {user.adoptions && user.adoptions.length > 0 ? (
                                <ul>
                                    {user.adoptions.map((adoption) => (
                                        // Check if the animal is available, in foster, and not in the array
                                        adoption.animal.available && adoption.foster && !uniqueAnimalIds.includes(adoption.animal.id) && (
                                            // Add the animal ID to the array
                                            uniqueAnimalIds.push(adoption.animal.id),
                                            <li key={adoption.id}>
                                                <p>{adoption.animal.name}</p>
                                                <Link to={`/animalDetails/${adoption.animal.id}`}>
                                                    <p><img className="animal-detail-picture" src={adoption.animal.urlPic} alt={adoption.animal.name} /></p>
                                                </Link>
                                            </li>
                                        )
                                    ))}
                                </ul>
                            ) : (
                                <p>No fostered animals.</p>
                            )}
                        </>
                    )}
                </>
            ) : (
                <p>Loading...</p>
                )}
            
            
                <Link to={`/editUserProfile/${getUserId}`} >
                    <button id="edit-profile">Edit</button>
                </Link>
            

                
        </div>
    );
}
