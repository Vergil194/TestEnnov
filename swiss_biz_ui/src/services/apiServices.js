import axios from 'axios';
import { toast } from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';

const apiService = axios.create({
    baseURL: 'https://localhost:7053',
    headers: {
        'Content-Type': 'application/json',
    },
});

apiService.interceptors.response.use(
    (response) => {
        const statusCode = response.status;
        console.log('test', statusCode);
        switch (statusCode) {
            case 200:
                toast.success('Resources loaded successfully', {
                    position: 'top-left',
                });
                break;
            default:
                break;
        }

        return response;
    },
    (error) => {
        const statusCode = error.response ? error.response.status : null;
        console.log('test', statusCode);
        switch (statusCode) {
            case 400:
                toast.error('Bad Request: Please check your request data!', {
                    position: 'top-left',
                });
                break;
            case 401:
                toast.error('Unauthorized: Please authenticate to access this resource!', {
                    position: 'top-left',
                });
                break;
            case 404:
                toast.error('Not Found: This Company Uid is not found!', {
                    position: 'top-left',
                });
                break;

            default:
                toast.error('An unexpected error occurred!', {
                    position: 'top-left',
                });
                break;
        }

        return Promise.reject(error);
    }
);

export const getCompanies = async () => {
    try {
        const response = await apiService.get('/companies');
        return response.data;
    } catch (error) {
        console.error('Error fetching companies:', error);
        throw error;
    }
};

export const deleteCompany = async (uid) => {
    try {
        const response = await apiService.delete(`/companies/delete/${uid}`);
        return response.data;
    } catch (error) {
        console.error('Error deleting company:', error);
        throw error;
    }
};

export const addCompanyDetail = async (uid) => {
    try {
        const response = await apiService.get(`/companies/Add/${uid}`);
        return response.data;
    } catch (error) {
        console.error('Error adding company detail:', error);
        throw error;
    }
};
