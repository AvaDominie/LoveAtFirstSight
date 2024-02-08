
import emailLogo from "./gmail-logo.png";
import IGLogo from "./instagram.png";
import FB from "./facebook.png"

import "./Footer.css"



export default function Footer({ loggedInUser, setLoggedInUser }) {
    return (
        <div className="footer">
            {loggedInUser ? (
                <footer>
                    <div className="logos">
                    <br />
                    <a href="mailto:LAFSpet@gmail.com">
                        <img src={emailLogo} alt="Lafs Logo" className="Email" />
                    </a>

                    <a href="https://www.instagram.com/lafspetadoption">
                        <img src={IGLogo} alt="Instagram Logo" className="Ig" />
                    </a>
                    <a href="https://www.facebook.com/LAFS.pet.adoption/">
                        <img src={FB} alt="Facebook Logo" className="Fb" />
                    </a>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div className="hours">
                        <h4>Hours of Operation</h4>
                        <hr />
                        <p><b>Monday-Friday</b>: 10:00am-4:30pm</p>
                        <p><b>Saturday</b>: 8:30am-4:30pm</p>
                        <p><b>Sunday</b>: closed</p>
                    </div>
                    <br />
                    <br />
                    <div className="contact">
                        <h4>For More Information Please Contact</h4>
                        <hr />
                        <h4><b>(615) 297-2464</b></h4>
                    </div>
                    <br />
                    <br />
                    <div className="address">
                        <h4>Address</h4>
                        <hr />
                        <p><b>4423 Murphy Rd, Nashville, TN 37209</b></p>
                    </div>
                </footer>
            ) : null}
        </div>
    );
}
