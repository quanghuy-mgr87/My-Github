<template>
    <div class="hello">
        <!-- 
        1. Computed property: 
        2. Shorthands:
            - <a v-bind:href="url">...</a> rút gọn thành <a :href="url">...</a>
            - <a v-on:click="doSomething">...</a> rút gọn thành <a @click="doSomething">...</a>
        3. Dynamic Style
            3.1 Binding Class:
                - Ta có thể truyền vào v-bind:class để bật tắt class một cách linh hoạt
                    <div v-bind:class = "{active: isActive}"></div>
                    + class active sẽ áp dụng tùy theo tính đúng sai của thuộc tính dữ liệu isActive.
                    + Có thể bật tắt nhiều class bằng cách dùng nhiều field (trường) trong object.
                    + directive v-bind:class và thuộc tính class thông thường có thể được dùng cùng lúc với nhau.

                - Đối với Object :
                    + Nếu ta có template: 
                    <div class="static" 
                        v-bind:class="{active: isActive, 'text-danger': hasError}">
                    </div>
                    + Nếu dữ liệu truyền vào là:
                    data:{
                        isActive: true,
                        hasError: false
                    }
                    + Thì kết quả render sẽ là:
                    <div class="static active"></div>
                    + Nếu isActive true và hasError true thì render sẽ thành:
                    <div class="static active 'text-danger'"></div>

                - Đối với mảng:
                    + Ta có thể truyền một mảng vào v-bind:class để áp dụng 1 danh sách class:
                        <div v-bind:class = "[activeClass, errorClass]"></div>
                    + Dữ liệu truyền vào:
                        data: {
                            activeClass: 'active',
                            errorClass: 'text-danger'
                        }
                    + Thì kết quả render ra sẽ là:
                        <div class = "active text-danger"></div>
                    + Nếu muốn bật tắt theo điều kiên một class trong danh sách, bạn có thể dùng một toán tử 3 ngôi:
                        <div v-bind:class = "[isActive ? activeClass : '', errorClass]">
                    + Đoạn code trên sẽ luôn áp dụng class errorClass, nhưng chỉ áp dụng activeClass khi isActive mang giá trị đúng.
                    + Cách làm này có thể hơi dài dòng nếu có nhiều class theo điều kiện. Do đó ta có thể dùng cú pháp:
                        <div v-bind:class = "[{active:isActive}, errorClass]"></div>

            3.2 Binding style:
                - Cú pháp object của v-bind:style trông giống với CSS thông thường, chỉ khác ở chỗ nó là một object javascript.
                    <div v-bind:style = "{ color: activeColor, fontSize: fontSize + 'px' }"></div>
                    <div v-bind:style = "styleObject"></div>
                
                data:{
                    activeColor: 'red',
                    fontSize: 30
                }

                hoặc

                data:{
                    styleObject:{
                        color: 'red',
                        fontSize: '13px'
                    }
                }

                - Đối với mảng: 
                    + Cú pháp mảng của v-bind:style cho phép áp dụng nhiều object style trên cùng 1 phần tử web (Lưu ý về thứ tự áp dụng)
                    <div v-bind:style = "[baseStyles, overridingStyles]"></div>
                Lưu ý: cách viết  dash-case sẽ được chuyển thành cách viết camelCase(VD: font-size -> fontSize)

        -->
        <button v-on:click="counter++">Tăng cừu</button> <br /><br />
        <button v-on:click="counter--">Giảm cừu</button> <br /><br />
        Bộ đếm {{ counter }} con cừu <br />
        <br />
        <!-- với demCuu() là methods thì ko đóng ngoặc đc, còn với computed thì ko thêm đc -->
        {{ res }} | {{ demCuu() }} con cừu
        <hr />
        <!-- chạy cái này vẫn call dem cuu, tức là methods sẽ chạy bất kì khi nào đc gọi, còn computed chỉ chạy khi 
        biến nó đang xử lý bị tác động -->
        <button @click="chayBoDem()">Chạy bộ đếm 2</button> <br />
        <br />
        Bộ đếm {{ counter2 }} con cừu <br />
        <br />
        <br />
        <hr />

        <div class="block" :class="{ red: isRed }" @click="isRed = !isRed"></div>
        <div class="block" :class="{ green: isGreen }" @click="isGreen = !isGreen"></div>
        <div class="block" :class="{ blue: isBlue }" @click="isBlue = !isBlue"></div>

        <hr />
        <!-- Binding class -->
        <p :class="[isRed ? cls_red : '', cls_block2]">Đây là 1 đoạn văn</p>
        <p :class="[{ red: isRed }, cls_block2]">Đây là đoạn văn 2</p>

        <hr />
        <!-- Binding style -->
        <p :style="{ fontSize: 30 + 'px', color: 'red' }">Helu</p>
        <p :style="objStyle">Belu</p>
        <p :style="[objStyle1, objStyle2]">Celu</p>
    </div>
</template>

<script>
export default {
    name: "HelloWorld",
    props: {
        msg: String,
    },
    data() {
        return {
            counter: 1,
            counter2: 1,
            isRed: true,
            isGreen: false,
            isBlue: true,
            cls_red: "red",
            cls_block2: "block2",
            objStyle: {
                fontSize: 30 + "px",
                color: "green",
            },
            objStyle1: {
                fontSize: 20 + "px",
                color: "gray",
            },
            /*
                nếu có cùng 1 loại style VD: color ở objStyle1 và objStyle2 trong cùng 1 binding thì sẽ áp dụng cái cuối cùng
                ở đây là 50 px 
            */
            objStyle2: {
                fontSize: 50 + "px",
                color: "white",
                backgroundColor: 'black'
            },
        };
    },
    computed: {
        res() {
            console.log("Call Computed");
            return this.counter > 5 ? "Có nhiều hơn 5 " : "Có ít hơn 5 ";
        },
    },
    methods: {
        demCuu() {
            console.log("Call dem cuu");
            return this.counter > 5 ? "Có nhiều hơn 5 " : "Có ít hơn 5 ";
        },
        chayBoDem() {
            this.counter2++;
        },
    },
};
</script>

<style>
.red {
    background-color: red !important;
    color: red !important;
}
.green {
    background-color: green !important;
    color: green !important;
}
.blue {
    background-color: blue !important;
    color: blue !important;
}
.block {
    width: 100px;
    height: 100px;
    background-color: bisque;
}
.block2 {
    font-size: 30px;
    background-color: gray !important;
}
</style>
