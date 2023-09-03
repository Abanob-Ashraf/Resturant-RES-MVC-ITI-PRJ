
document.addEventListener('DOMContentLoaded', function () {
    const cartBody = document.getElementById('cart-body');
    const totalInput = document.getElementById('TotalPriceSend');
    const TotalCell = document.getElementById('total');
    const dishesInput = document.querySelector('input[name="OrderDishes"]');
    const checkoutButton = document.querySelector(".checkout");
    const isCash = document.querySelector('#IsCash');
    TotalCell.innerText = "0";




    const orders = JSON.parse(localStorage.getItem('orders')) || [];

    fetchDishes(orders);

    function fetchDishes(ids) {
        if (ids.length === 0) {
            cartBody.innerHTML = '<tr><td class="w-100 p-5 text-center fw-bold text-danger" colspan="5">Your cart is empty. <i class="fa-regular fa-face-sad-cry"></i></td></tr>';
            checkoutButton.setAttribute("disabled", "true")
            return;
        }
        checkoutButton.removeAttribute("disabled")


        ids.forEach(dishId => {
            fetch(`/Client/Dish/DishApi/${dishId}`)
                .then(response => response.json())
                .then(data => {
                    if (data) {
                        const row = createCartItemRow(data);
                        cartBody.appendChild(row);

                    }
                })
                .catch(error => {
                    console.error('Error fetching dish:', error);
                });
        });

    }
    checkoutButton.addEventListener('click', function (event) {
        const cartRows = document.querySelectorAll('.item');

        const cartVM = {

            PaymentMethodID: isCash.checked ? 1 : 2,
            cartDishes: []
        };

        cartRows.forEach(row => {
            const dishId = row.getAttribute('data-id');
            const quantity = parseInt(row.querySelector('input').value, 10);

            const cartDish = {
                DishId: dishId,
                Quantity: quantity
            };

            cartVM.cartDishes.push(cartDish);
        });

        const dishesQueryString = encodeURIComponent(JSON.stringify(cartVM));
        dishesInput.value = dishesQueryString;
    });

    function createCartItemRow(dish) {

        const row = document.createElement('tr');
        row.className = 'item';
        row.dataset.id = dish.DishId;

        const buttonsCell = document.createElement('td');
        buttonsCell.className = 'buttons';
        buttonsCell.innerHTML = '<i class="fa-solid fa-xmark delete-btn"></i>';
        buttonsCell.addEventListener('click', function () {
            const dishId = dish.DishId.toString();
            const index = orders.indexOf(dishId);

            if (index !== -1) {
                orders.splice(index, 1);
                localStorage.setItem('orders', JSON.stringify(orders));
            }
            row.remove();
            TotalCell.textContent = "0";
            document.querySelectorAll(".total-price").forEach(el => {

                TotalCell.textContent = parseInt(TotalCell.textContent) + parseInt(el.textContent);
            })
            if (document.querySelectorAll(".total-price").length === 0) {
                cartBody.innerHTML = '<tr><td class="w-100 p-5 text-center fw-bold text-danger" colspan="5">Your cart is empty. <i class="fa-regular fa-face-sad-cry"></i></td></tr>';
                checkoutButton.setAttribute("disabled", "true")
            }
            totalInput.value = parseInt(TotalCell.innerText);

        });
        row.appendChild(buttonsCell);

        const imageCell = document.createElement('td');
        imageCell.className = 'image';
        imageCell.innerHTML = '<img src="" />'
        imageCell.children[0].src = `/assets/images/sandwitches/${dish.DishImageName}.png`;
        row.appendChild(imageCell);

        const nameCell = document.createElement('td');
        nameCell.className = 'product-name py-4 fw-bold fs-5';
        nameCell.textContent = dish.DishName;
        row.appendChild(nameCell);

        const quantityCell = document.createElement('td');
        quantityCell.className = '';
        const quantityDiv = document.createElement('div');
        quantityDiv.className = 'quantity d-flex align-items-center justify-content-evenly';


        const plusButton = document.createElement('button');
        plusButton.className = 'plus-btn';
        plusButton.type = 'button';
        plusButton.name = 'button';
        plusButton.addEventListener("click", (e) => {
            e.preventDefault();
            let val = inputField.value
            if (val <= 100) {
                val = parseInt(val) + 1;
            } else {
                val = 100;
            }

            inputField.value = val

            priceCell.innerText = dish.DishPrice * parseInt(inputField.value)
            TotalCell.textContent = 0;
            document.querySelectorAll(".total-price").forEach(el => {

                TotalCell.textContent = parseInt(TotalCell.textContent) + parseInt(el.textContent);
            })
            totalInput.value = parseInt(TotalCell.innerText);


        })
        plusButton.innerHTML = '<i class="fa-regular fa-square-plus btn btn-success mx-2"></i>';

        const inputField = document.createElement('input');
        inputField.name = `quantity-${dish.DishId}`
        inputField.type = 'text';
        inputField.disabled = '';
        inputField.name = 'name';
        inputField.value = '1';

        const minusButton = document.createElement('button');
        minusButton.className = 'minus-btn';
        minusButton.type = 'button';
        minusButton.name = 'button';
        minusButton.addEventListener("click", (e) => {
            e.preventDefault();
            let val = inputField.value
            if (val > 1) {
                val = val - 1;
            } else {
                val = 1;
            }

            inputField.value = val

            priceCell.innerText = dish.DishPrice * parseInt(inputField.value)
            TotalCell.textContent = 0;
            document.querySelectorAll(".total-price").forEach(el => {

                TotalCell.textContent = parseInt(TotalCell.textContent) + parseInt(el.textContent);
            })
            totalInput.value = TotalCell.innerTex;

        })
        minusButton.innerHTML = '<i class="fa-regular fa-square-minus btn btn-danger mx-2"></i>';


        quantityDiv.appendChild(plusButton);
        quantityDiv.appendChild(inputField);
        quantityDiv.appendChild(minusButton);

        quantityCell.appendChild(quantityDiv);
        row.appendChild(quantityCell);

        const priceCell = document.createElement('td');
        priceCell.className = 'total-price';
        priceCell.textContent = `${dish.DishPrice}`;
        row.appendChild(priceCell);
        TotalCell.innerText = parseInt(TotalCell.innerText) + dish.DishPrice

        return row;
    }

})