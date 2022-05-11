<template>
  <div class="row post">
    <div class="col-lg-12 pt-2 mt-4 pl-0 pr-0 postBox" v-for="val in baiViets" :key="val.id">
      <div class="row name pl-3 pr-3">
        <div class="col-lg-1">
          <img id="avatar" :src="val.avatar" alt="" />
        </div>
        <div class="col-lg-10">
          <div id="text">{{ val.nguoiTao }}</div>
          <span>29 phút</span> <span style="font-size: 9px">&#8226;</span> <i class="fas fa-globe-asia"></i>
        </div>
        <div class="col-lg-1 moreHoriz">
          <i class="material-icons">more_horiz</i>
        </div>
      </div>
      <div class="col-lg-12 pl-3 pr-3 pb-2">
        <div class="statusContent">
          {{ val.noiDung }}
        </div>
        <!-- <div class="viewAllStatus" type="button" @click="viewAllContent">Xem thêm</div> -->
      </div>
      <div class="image">
        <img :src="val.linkAnh" alt="" />
      </div>
      <div class="col-lg-12 pt-2 mb-2 pl-3 pr-3"><i class="fas fa-thumbs-up"></i><span style="margin-left: 9px;">6,9K</span></div>
      <div class="col-lg-12">
        <div class="line"></div>
      </div>
      <div class="col-lg-12 pt-1 pl-3 pr-3 pb-1">
        <div class="row px-2">
          <div class="col-lg-4 pt-2 mx-0 px-0 statusItem">
            <a class="nav-link" href="" style="padding: 0px">
              <i class="far fa-thumbs-up"></i>
              <span>Thích</span>
            </a>
          </div>
          <div class="col-lg-4 pt-2 mx-0 px-0 statusItem">
            <a class="nav-link" href="" style="padding: 0px">
              <i class="far fa-comment-alt"></i>
              <span>Bình luận</span>
            </a>
          </div>
          <div class="col-lg-4 pt-2 mx-0 px-0 statusItem">
            <a class="nav-link" href="" style="padding: 0px">
              <i class="fa fa-share-square-o"></i>
              <span>Chia sẻ</span>
            </a>
          </div>
        </div>
      </div>
      <div class="col-lg-12 mb-3">
        <div class="line"></div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  data: function() {
    return {
      baiViets: [
        {
          id: 1,
          avatar: "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcR160xJNuIEy676ns4LppT0jDWZxUD_uwLsKg&usqp=CAU",
          linkAnh:
            "https://scontent-hkt1-1.xx.fbcdn.net/v/t1.0-9/117039978_392300318415930_3999528415021311407_n.jpg?_nc_cat=107&_nc_sid=8bfeb9&_nc_ohc=Ob6mflr9pO8AX-hkShz&_nc_ht=scontent-hkt1-1.xx&oh=88b2b5e7b6f7b9c5b206db4cbd594cbd&oe=5F7D54E1",
          noiDung: "Тот, кто погас Будет ярче светить, чем кометы Пролетающие над планетой",
          nguoiTao: "Мария Золотова",
        },
        {
          id: 2,
          avatar: "https://i.pinimg.com/736x/29/ab/5a/29ab5acafc429ac807f72aece29a5695.jpg",
          linkAnh: "https://ttol.vietnamnetjsc.vn//2018/03/07/21/04/nu-sinh-17-tuoi-duoc-khen-dep-thuan-khiet-nhu-thien-su_11.jpg",
          noiDung: "Some example text some example text. John Doe is an architect and engineer",
          nguoiTao: "Quoc",
        },
        {
          id: 3,
          avatar: "https://i.pinimg.com/736x/29/ab/5a/29ab5acafc429ac807f72aece29a5695.jpg",
          linkAnh: "https://thuthuatnhanh.com/wp-content/uploads/2019/05/gai-xinh-toc-ngan-facebook.jpg",
          noiDung:
            "Beautiful girls all over the world, I could be chasing but my time would be wasted. They got nothin' on you baby. Nothin' on you baby. They might say hi and I might say hey. But you shouldn't worry about what they say. 'Cause they got nothin' on you baby. Nothin' on you baby",
          nguoiTao: "Quoc",
          //   noiDung: "Some example text some example text. John Doe is an architect and engineer",
        },
        {
          id: 4,
          avatar: "https://i.pinimg.com/736x/29/ab/5a/29ab5acafc429ac807f72aece29a5695.jpg",
          linkAnh: "https://i.pinimg.com/736x/29/ab/5a/29ab5acafc429ac807f72aece29a5695.jpg",
          noiDung: "Some example text some example text. John Doe is an architect and engineer",
          nguoiTao: "Quoc",
        },
      ],
    };
  },
  methods: {
    viewAllContent() {},
  },
};
</script>
<style scoped>
.postBox {
  border-radius: 10px;
  height: auto;
}
.post > .col-lg-12 {
  background-color: rgb(36, 37, 39);
}
.moreHoriz > i {
  color: rgb(176, 179, 184);
  height: 36px;
  width: 36px;
  text-align: center;
  padding: 6px 0px;
  border-radius: 20px;
  cursor: pointer;
}
.moreHoriz > i:hover {
  background-color: #3a3b3c;
}
#avatar {
  width: 41px;
  height: 41px;
  margin: 3px 0px;
}
span {
  font-size: 14px;
  font-weight: 400;
}
#text {
  font-weight: 500;
  font-size: 16px;
  color: #e4e6eb;
}
.name > .col-lg-10 > span {
  font-weight: 400;
  font-size: 13px;
  color: rgb(176, 179, 184);
}
.name > .col-lg-10 > i {
  font-size: 13px;
  color: rgb(176, 179, 184);
}
.image img {
  width: 100%;
  height: auto;
}
.fa-thumbs-up {
  color: #2b89ff;
}
.nav-link > span {
  font-weight: 500;
}

/* 1 dòng */
.statusContent {
  display: -webkit-box;
  height: 16px * 1.3 * 3;
  -webkit-line-clamp: 3;
  -webkit-box-orient: vertical;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: pre-wrap;
}

.statusContent:hover {
  overflow: visible;
  -webkit-box-orient: horizontal;
}
.viewAllStatus {
  font-weight: 500;
}
.viewAllStatus:hover {
  text-decoration: underline;
}
</style>
