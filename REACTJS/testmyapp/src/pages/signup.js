// Filename - pages/signup.js

import React, { useState } from "react";
import { ToastContainer, toast } from 'react-toastify';
import axios from "axios";

const apiUrl = process.env.REACT_APP_API_KEY;
const SignUp = () => {
	const [userName, setUserName] = useState("");
	const [password, setPassword] = useState("");
	const [avatarUrl, setAvatarUrl] = useState("");
	const [isActive, setIsActive] = useState(true);
  
	const handleSave = async () => {
		try {
		  const response = await axios.post(apiUrl + "USERS/AddUser", {
				"id": 0,
				"createdate": "2023-12-08T08:37:04.880Z",
				"isactive": isActive,
				"usrname": userName,
				"usrpass": password,
				"usravatar": avatarUrl
			  
		  }, {
			headers: {
			  'Content-Type': 'application/json',
			  // Diğer gerekli başlıkları ekleyebilirsiniz.
			},
		  });
	
		  // Handle successful response, show toast, etc.
		  console.log(response.data);
		  toast.success("User created successfully!",{
			position: toast.POSITION.TOP_RIGHT,
		  });
		  window.location.href = "/";
		} catch (error) {
		  // Handle error, show toast, etc.
		  console.error("Error creating user:", error);
		  toast.error("Error creating user. Please try again.");
		}
	  };

	return (
		<div>
			<div className="container">
				<h1>User Create</h1>
				<div className="mb-3 row">
  				  <label for="staticEmail" className="col-sm-2 col-form-label">User Name</label>
  				  <div className="col-sm-10">
  				    <input type="text" className="form-control" id="staticEmail" value={userName} onChange={(e) => setUserName(e.target.value)}/>
  				  </div>
  				</div>
  				<div className="mb-3 row">
  				  <label for="inputPassword" className="col-sm-2 col-form-label">Password</label>
  				  <div className="col-sm-10">
  				    <input type="password" className="form-control" id="inputPassword" value={password} onChange={(e) => setPassword(e.target.value)}/>
  				  </div>
  				</div>
				  <div className="mb-3 row">
  				  <label for="inputAvatar" className="col-sm-2 col-form-label">Avatar Url</label>
  				  <div className="col-sm-10">
  				    <input type="text" className="form-control" id="inputAvatar" value={avatarUrl} onChange={(e) => setAvatarUrl(e.target.value)}/>
  				  </div>
  				</div>
				<div className="mb-3 row">
					<div class="form-check">
					  <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1" checked={!isActive} onChange={() => setIsActive(false)}/>
					  <label class="form-check-label" for="flexRadioDefault1">
					    Pasif
					  </label>
					</div>
					<div class="form-check">
					  <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" checked={isActive} onChange={() => setIsActive(true)} />
					  <label class="form-check-label" for="flexRadioDefault2">
					    Aktif
					  </label>
					</div>
				</div>
				<div className="mb-3 row">
					<button className="btn btn-primary" onClick={handleSave}>Kaydet</button>
				</div>
			</div>
		</div>
	);
};

export default SignUp;
