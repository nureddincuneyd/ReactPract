// Filename - pages/index.js
import React, { useEffect, useState } from "react";
import axios from "axios"
import 'bootstrap/dist/css/bootstrap.min.css';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import {UserModal, handleClose, handleShow } from '../components/userModal';
import { Nav, NavLink, NavMenu } from "../components/NavbarElements";
import './specialCSS.css'

const apiUrl = process.env.REACT_APP_API_KEY;

const showToastMessage = (text) => {
	toast.success(text, {
	  position: toast.POSITION.TOP_RIGHT,
	});
};
const Home = () => {

	const [get, setGet] = useState(null);
	const [selectedVeri, setSelectedVeri] = useState(null);
	
	
  
	useEffect(() => {
	  axios.get(apiUrl + 'USERS/GetAll')
		.then((response) => {
		  setGet(response.data.data); // "data" anahtarından liste verisine erişim
		})
		.catch((error) => {
		  console.error("Error fetching data:", error);
		});
	}, []);

	const updateClick  = async (id) =>{
		try {
			
			console.log(id);
			id = parseInt(id);
			
			const response = await axios.post(
				apiUrl + "USERS/GetByPk?id="+id
			  );
		  
			console.log('API Response:', response.data);
			setSelectedVeri(response.data);
		  } catch (error) {
			console.error('Veri alınamadı', error);
		  }
	}

	const deleteClick = async (id)=>{
		try{
			console.log(id);
			id = parseInt(id);
			
			const response = await axios.post(
				apiUrl + "USERS/RemoveUser?id="+id
			  );
		  
			console.log('API Response:', response.data);
			window.location.reload(true);
		}catch(err){

			console.error('Veri alınamadı', err);
		}
	}
	
	return (
	  <div className="container">
		<h1>HomePage</h1>
		<p>API URL: {apiUrl}</p>
  
		{get ? (
		  <div>
			<div className="btn-group">
			<h2>Users</h2>
			<div className="text-right">
				<NavLink to="/sign-up" activeStyle>
					<button className="btn btn-primary">New User</button>
				</NavLink>
			</div>
			</div>
			<table className="table table-hover">
				<thead>
					<th>#</th>
					<th>UserName</th>
					<th>Password</th>
					<th></th>
					<th>Action</th>
				</thead>
				<tbody>
					{get.map((user) => (
						<tr>
							<td>{user.id}</td>
							<td>{user.usrname}</td>
							<td>{user.usrpass}</td>
							<td>
								<div className="btn-group specialRight">
									<button className="btn btn-primary btn-sm" onClick={handleShow()}>up</button> 
									<button className="btn btn-danger btn-sm" onClick={() => deleteClick(user.id)}>del</button>
									<ToastContainer />
								</div>
							</td>
						</tr>
			  		))}
				</tbody>
			</table>
		  </div>
		  
		) : (
		  <p>Loading...</p>
		)}
		<UserModal/>
	  </div>
	);
  };
  //<!--() => updateClick(parseInt(user.id)) -->
  export default Home;