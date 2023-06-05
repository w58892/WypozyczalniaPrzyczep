import axios from "axios";
import { hostName } from "./host";

export const addUser = async (user) => {
	try {
		const res = await axios.post(`${hostName}/api/User/Add`, user);
		return res;
	} catch (error) {
		return error.response.data;
	}
};

export const login = async (user) => {
	try {
		const res = await axios.post(`${hostName}/api/User/Login`, user);
		const token = res.data;

		localStorage.setItem("token", token);
		return res;
	} catch (error) {
		return error.response.data;
	}
};

export function getToken(){
	const token = localStorage.getItem("token");

	if (token) {
		var base64Url = token.split(".")[1];
		var base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
		var jsonPayload = decodeURIComponent(
			atob(base64)
				.split("")
				.map(function (c) {
					return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
				})
				.join("")
		);
			return(JSON.parse(jsonPayload));
	}
return null;
}