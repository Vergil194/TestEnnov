<template>
    <div>
        <h1><span class="blue">&lt;</span>Table<span class="blue">&gt;</span> <span class="yellow">Company List</span></h1>

        <div
            style="margin-bottom: 25px; background-color: #3B4152;width: 79.5%; margin: auto;border-radius: 3px; padding: 5px;">
            <input class="input-add" v-model="newDetail" placeholder="par exemple CHE229009661">
            <button class="btn-add" @click="addNewDetail" :disabled="isLoading">Add Company</button>
        </div>
        <table class="container">
            <thead>
                <tr>
                    <th>
                        <h1>UID</h1>
                    </th>
                    <th>
                        <h1>Name</h1>
                    </th>
                    <th>
                        <h1>Head Office</h1>
                    </th>
                    <th>
                        <h1>Legal Form</h1>
                    </th>
                    <th>
                        <h1>Modification Date</h1>
                    </th>
                    <th>
                        <h1>Address</h1>
                    </th>
                    <th>
                        <h1>Action</h1>
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="company in companies" :key="company.uid">
                    <td>{{ company.uid }}</td>
                    <td>{{ company.name }}</td>
                    <td>{{ company.headOffice }}</td>
                    <td>{{ company.legalform }}</td>
                    <td>{{ company.sogcDate }}</td>
                    <td>{{ company.adresses.adress }}</td>
                    <td>
                        <button class="btn-delete" @click="deleteCompany(company.uid)" :disabled="isLoading">Delete</button>
                    </td>
                </tr>
            </tbody>
        </table>

        <div v-if="isLoading">Loading...</div>
    </div>
</template>

<script>
import { getCompanies, deleteCompany, addCompanyDetail } from "../services/apiServices";

export default {
    data() {
        return {
            companies: [],
            isLoading: false,
        };
    },
    methods: {
        async fetchCompanies() {
            try {
                this.isLoading = true;
                this.companies = await getCompanies();
            } catch (error) {
                console.error('Error fetching companies:', error);
            } finally {
                this.isLoading = false;
            }
        },
        async deleteCompany(uid) {
            try {
                console.log(uid)
                this.isLoading = true;
                await deleteCompany(uid);
                this.fetchCompanies();
            } catch (error) {
                console.error('Error deleting company:', error);
            } finally {
                this.isLoading = false;
            }
        },
        async addNewDetail() {
            try {
                this.isLoading = true;
                await addCompanyDetail(this.newDetail);
                this.fetchCompanies();
            } catch (error) {
                console.error('Error adding new detail:', error);
            } finally {
                this.isLoading = false;
            }
        },
    },
    mounted() {
        this.fetchCompanies();
    },
};
</script>

<style scoped>
@charset "UTF-8";
@import url(https://fonts.googleapis.com/css?family=Open+Sans:300,400,700);

body {
    font-family: 'Open Sans', sans-serif;
    font-weight: 300;
    line-height: 1.42em;
    color: white;
    background-color: #1F2739;
}

h1 {
    font-size: 3em;
    font-weight: 300;
    line-height: 1em;
    text-align: center;
    color: #4DC3FA;
}

h2 {
    font-size: 1em;
    font-weight: 300;
    text-align: center;
    display: block;
    line-height: 1em;
    padding-bottom: 2em;
    color: #FB667A;
}

h2 a {
    font-weight: 700;
    text-transform: uppercase;
    color: #FB667A;
    text-decoration: none;
}

.blue {
    color: black;
}

.yellow {
    color: #49cc90;
}

.input-add {
    border: 3px solid #62a03f;
    border-radius: 4px 0 0 4px;
    margin: 0;
    outline: none;
    width: 250px;
    padding: 5px 10px;
    margin-right: 10px;
    border-radius: 4px;
}

.btn-add,
.btn-delete {
    background: transparent;
    border: 2px solid gray;
    border-radius: 4px;
    box-shadow: 0 1px 2px rgba(0, 0, 0, .1);
    color: white;
    font-family: sans-serif;
    font-size: 14px;
    font-weight: 700;
    padding: 5px 23px;
    transition: all .3s;
}

.btn-add:hover {
    cursor: pointer;
    background-color: #49cc90;
}

.btn-delete:hover {
    cursor: pointer;
    background-color: #FB667A;
}

.container th h1 {
    font-weight: bold;
    font-size: 1em;
    text-align: left;
    color: #185875;
}

.container td {
    font-weight: normal;
    font-size: 0.8em;
    -webkit-box-shadow: 0 2px 2px -2px #0E1119;
    -moz-box-shadow: 0 2px 2px -2px #0E1119;
    box-shadow: 0 2px 2px -2px #0E1119;
    color: white;
}

.container {
    text-align: left;
    overflow: hidden;
    width: 80%;
    margin: 0 auto;
    display: table;
    padding: 0 0 8em 0;
}


.container th {
    padding-bottom: 2%;
    padding-top: 2%;
    padding-left: 2%;
}

/* Background-color of the odd rows */
.container tr:nth-child(odd) {
    background-color: #323C50;
}

.container td {
    padding-bottom: 10px;
    padding-top: 10px;
    padding-left: 25px;
    padding-right: 25px;
}

/* Background-color of the even rows */
.container tr:nth-child(even) {
    background-color: #2C3446;
}

.container th {
    background-color: #1F2739;
}

.container td:first-child {
    color: #FB667A;
}

.container tr:hover {
    background-color: #464A52;
    -webkit-box-shadow: 0 6px 6px -6px #0E1119;
    -moz-box-shadow: 0 6px 6px -6px #0E1119;
    box-shadow: 0 6px 6px -6px #0E1119;
}

.container td:hover {
    color: #FB667A;
}

@media (max-width: 800px) {

    .container td:nth-child(4),
    .container th:nth-child(4) {
        display: none;
    }
}</style>
