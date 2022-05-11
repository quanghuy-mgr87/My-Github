<template>
  <div class="row">
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
      <div v-for="val in baiViets" :key="val.id">
        <div v-if="val.id == id">
          <div>
            <img id="avatar" :src="val.linkAnh" alt="" />
            <span>{{ val.nguoiTao }}</span>
          </div>
          <hr />
          <div>
            <p>{{ val.noiDung }}</p>
          </div>
          <div>
            <img id="image" :src="val.linkAnh" alt="" />
          </div>
          <br />
        </div>
      </div>
    </div>
    <div class="col-lg-4"></div>
  </div>
</template>
<script>
export default {
  data: function() {
    return {
      id: 0,
      baiViets: [
        {
          id: 1,
          linkAnh: "https://i.pinimg.com/280x280_RS/82/50/d0/8250d04e9d24487b578f7a6f50402807.jpg",
          noiDung: "Some example text some example text. John Doe is an architect and engineer",
          nguoiTao: "Quoc",
        },
        {
          id: 2,
          linkAnh: "https://ttol.vietnamnetjsc.vn//2018/03/07/21/04/nu-sinh-17-tuoi-duoc-khen-dep-thuan-khiet-nhu-thien-su_11.jpg",
          noiDung: "Some example text some example text. John Doe is an architect and engineer",
          nguoiTao: "Quoc",
        },
        {
          id: 3,
          linkAnh: "https://thuthuatnhanh.com/wp-content/uploads/2019/05/gai-xinh-toc-ngan-facebook.jpg",
          noiDung: "Some example text some example text. John Doe is an architect and engineer",
          nguoiTao: "Quoc",
        },
        {
          id: 4,
          linkAnh: "https://i.pinimg.com/736x/29/ab/5a/29ab5acafc429ac807f72aece29a5695.jpg",
          noiDung: "Some example text some example text. John Doe is an architect and engineer",
          nguoiTao: "Quoc",
        },
      ],
    };
  },
  created() {
    this.id = this.$route.params.id;
  },
};
</script>
