import "./Home.css"

import { useState } from "react";

export default function Home() {
    const images = [
        "https://i.pinimg.com/736x/f7/9a/24/f79a2432c24f17733955360195a905bb.jpg",
        "https://i.pinimg.com/736x/4b/02/87/4b028782746674481d023892ea3b0f39.jpg",
        "https://i.pinimg.com/736x/14/4f/b7/144fb7b32894fc595b6c119a9ba6c103.jpg",
        "https://i.pinimg.com/736x/eb/1c/3e/eb1c3e6df8ab7ff784bb3a35743044a8.jpg",
        "https://i.pinimg.com/736x/02/34/38/02343816e9121c1064a1af236ab90e7c.jpg"
    ];

    const [currentImageIndex, setCurrentImageIndex] = useState(0);

    const nextSlide = () => {
        setCurrentImageIndex((prevIndex) => (prevIndex === images.length - 1 ? 0 : prevIndex + 1));
    };

    const prevSlide = () => {
        setCurrentImageIndex((prevIndex) => (prevIndex === 0 ? images.length - 1 : prevIndex - 1));
    };

    return (
        <div className="container">
            <br />
            <h2 className="welcome">Welcome to Love At First Sight Adoption Center!</h2>
            <br />

            <div className="slider">
                <img src={images[currentImageIndex]} style={{ width: "100%" }} alt={`Slide ${currentImageIndex + 1}`} />
                <button className="prev" onClick={prevSlide}>&#10094;</button>
                <button className="next" onClick={nextSlide}>&#10095;</button>
            </div>
            <br />
            <br />
            <br />
            <h2 className="about-us">About Us</h2>
            <br />
            {/* About Us Paragraphs */}
            <p>Love at First Sight! stands as a beacon of hope for pets in Music City, Tennessee. Established in 1995 by dedicated veterinarians, Dr. Craig Prior and Dr. Grif Haber, this adoption center has been a catalyst for change in the lives of over 8,500 pets, finding them loving homes in the heart of Nashville.</p>
            <p>Motivated by the distressing sight of countless stray and abandoned animals in middle Tennessee, Dr. Prior and Dr. Haber took decisive action. Love at First Sight! emerged as a solution to address the challenges of pet overpopulation, emphasizing responsible pet ownership through education on spaying and neutering.</p>
            <p>The adoption center sources the majority of its pets from families across Tennessee facing unexpected litters and collaborates with local animal shelters to alleviate the strain of puppy and kitten overflows. Aiming to be the premier destination for adopting healthy puppies and kittens in Nashville, Love at First Sight! is committed to creating awareness and fostering a lifetime of health and wellness for every adopted pet.</p>
            <p>Prior to adoption, each puppy and kitten undergoes meticulous examination by the skilled veterinarians at VCA Murphy Road Animal Hospital, located just across the street. Accepted pets receive essential vaccinations, thorough parasite treatment, soothing medicated baths, and ample love and care until they find their forever homes.</p>
            <p>If you or someone you know is grappling with the challenges of an unexpected pet litter, Love at First Sight! is here to help. Connect with our adoption specialists for guidance and support in making a positive difference in the lives of these furry companions.</p>
        </div>
    );
}

