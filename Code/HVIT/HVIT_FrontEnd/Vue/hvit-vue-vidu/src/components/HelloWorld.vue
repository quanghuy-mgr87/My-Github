<template>
    <div>
        <!-- <div class="fa fa-car fa-4x" :style="`color: ${turnOn ? 'yellow' : 'grey'}`"></div>
        <br>
        <button @click="clickBtn">Turn {{ turnOn ? "off" : "on" }}</button> -->
         <ul>
            <li v-for="(item, index) in dsHoaQua" :key="index">{{ index }} - {{ item.ten }} có màu {{ item.mauSac }}</li>
        </ul>
    </div>
</template>

<script>
export default {
    name: "HelloWorld",
    data() {
        return {
            turnOn: false,
             dsHoaQua: [{
                        ten: "quả cam",
                        mauSac: "cam"
                    }, {
                        ten: "quả chanh",
                        mauSac: "xanh"
                    }, {
                        ten: "quả bưởi",
                        mauSac: "vàng"
                    }, {
                        ten: "quả mít",
                        mauSac: "xanh"
                    }, ],
        };
    },
    methods: {
        clickBtn() {
            this.turnOn = !this.turnOn;
            console.log(this.turnOn);
        },
    },
};
</script>
<style></style>
