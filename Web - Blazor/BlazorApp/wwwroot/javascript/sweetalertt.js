function customDelete() {
    return new Promise(resolve => {
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            resolve(result.isConfirmed);
        })
    });

}

function createCustomer() {
    return new Promise(resolve => {
        Swal.fire({
            icon: 'success',
            title: 'Success!',
            text: 'New Customer created',
        }).then((result) => {
            resolve(result.isConfirmed);
        })
    })
}

function editCustomer() {
    return new Promise(resolve => {
        Swal.fire({
            icon: 'warning',
            title: 'Are you sure?',
            text: 'Your changes will be updated',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, update it!'
        }).then((result) => {
            resolve(result.isConfirmed);
        })
    })
}

function updateCustomer() {
    return new Promise(resolve => {
        Swal.fire({
            icon: 'success',
            title: 'Success!',
            text: 'Customer has been updated'
        }).then((result) => {
            resolve(result.isConfirmed);
        })
    })
}

function invalidNewCustomer() {
    return new Promise(resolve => {
        Swal.fire({
            icon: 'error',
            title: 'Oops!',
            text: 'Please fill the required fields',
        }).then((result) => {
            resolve(result.isConfirmed);
        })
    })
}