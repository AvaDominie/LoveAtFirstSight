import { useEffect, useState } from "react";
import { getUserProfileById } from "../../managers/UserProfileManager";



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
            <h2>Profile Details</h2>
            {user ? (
                <>
                    <p>Full Name: {user.fullName}</p>
                    <p>Email: {user.email}</p>
                    <p>Address: {user.address}</p>
                </>
            ) : (
                <p>Loading...</p>
            )}
        </div>
    );
}